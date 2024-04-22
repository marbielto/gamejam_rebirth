using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform currentTarget;
    public Transform targetA;
    public Transform targetB;

    public float speed;

    public Transform bullet;
    public Transform pivot;
    public Transform enemy;

    private Rigidbody2D rb;

    public Animator enanim;

    private bool qualSegue = true;

    int side = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Transform>();
        currentTarget = targetA;
        enanim = GetComponent<Animator>();
    }

    void Update()
    {   
        if(currentTarget == targetA && transform.position == targetA.position)
        {   
            currentTarget = targetB;
            qualSegue = false;
        }
        if (currentTarget == targetB && transform.position == targetB.position)
        {   
            currentTarget = targetA;
            qualSegue = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if ((qualSegue && side == 1) || (!qualSegue && side == -1))
        {
            enemy.localScale = new Vector2(enemy.localScale.x * -1, enemy.localScale.y);
            side = side * -1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Transform obj = Instantiate(bullet, pivot.position, transform.rotation);
            obj.right = Vector2.right * side;
            enanim.SetTrigger("enattack");
        }
    }

    public void itsDied()
    {
        Destroy(gameObject);
    }


}
