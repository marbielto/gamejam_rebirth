using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{   
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public Animator anim;

    
    int side = 1;
    public Transform bullet;
    public Transform pivot;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal !=0)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            
        }

        if(isGrounded())
        {
            anim.SetBool("jumping", false);
        }
        else
        {
            anim.SetBool("jumping", true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
        }

        Flip();

        if(Input.GetKeyDown(KeyCode.RightArrow))
            side = 1;
        if(Input.GetKeyDown(KeyCode.LeftArrow))
            side = -1;
        
        transform.right = Vector2.right * side;

        if (Input.GetKeyDown(KeyCode.Z))
        {   
            anim.SetTrigger("attacking");
            Transform obj = Instantiate(bullet, pivot.position, transform.rotation);
            obj.right = Vector2.right * side;
        }
    }

    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= 1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "IsDamage")
        {
            SceneManager.LoadScene("Fase1");
        }
        
    }
}
