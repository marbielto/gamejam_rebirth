using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private GameObject enem;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<Enemy>().itsDied();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
    }
}
