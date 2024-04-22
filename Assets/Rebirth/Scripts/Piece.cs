using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour
{
    private GameController gcPlayer;
    public GameObject canvas;
    private GameObject p;

    void Start()
    {
        gcPlayer = GameController.gc;
        gcPlayer.pieces = 0f;
        p = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if (collision.gameObject.tag == "Player")
        {   
            Destroy(gameObject);
            gcPlayer.pieces = gcPlayer.pieces + 25f * Time.fixedDeltaTime;
            gcPlayer.piecesText.text = gcPlayer.pieces.ToString();
            Debug.Log(gcPlayer.pieces);

            if (gcPlayer.pieces >= 4f)
            {
                canvas.SetActive(true);
                Time.timeScale = 0f;
                p.GetComponent<PlayerMovement>().enabled = false;
            }
            
        }
    }
    
}
