using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet2 : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 300);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Fase1");
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }
}
