using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController gc;
    public Text piecesText;
    public float pieces = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        if(gc == null)
        {
            gc = this;
        }
        else if(gc != this)
        {
            Destroy(gameObject);
        }
    }

    /*void LoadScene()
    {
        SceneManager.LoadScene("Fase1");
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
