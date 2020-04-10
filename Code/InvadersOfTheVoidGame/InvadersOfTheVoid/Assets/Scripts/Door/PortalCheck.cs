using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCheck : MonoBehaviour
{
    //Reference gives the ability to use the bool between scripts
    private InteractKey keyReference1;
    private InteractKey keyReference2;
    private InteractKey keyReference3;

    public void Start()
    {
        keyReference1 = GameObject.Find("Crystal_01").GetComponent<InteractKey>();
       

        keyReference2 = GameObject.Find("Crystal_02").GetComponent<InteractKey>();
       

        keyReference3 = GameObject.Find("Crystal_03").GetComponent<InteractKey>();
        
    }

    //Check if player is at scene, moves to the next scene
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player") && (keyReference1.hasKey == true) && (keyReference2.hasKey == true) && (keyReference3.hasKey == true) && (keyReference3.hasKey == true))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Door Check");
            keyReference1.hasKey = false;
            keyReference2.hasKey = false;
            keyReference3.hasKey = false;
        }
    }

}
