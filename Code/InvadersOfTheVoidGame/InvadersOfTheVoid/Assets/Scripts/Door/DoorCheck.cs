using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCheck : MonoBehaviour
{
    //Reference gives the ability to use the bool between scripts
    private InteractKey keyReference;  

    public void Start()
    {
        keyReference = GameObject.Find("key").GetComponent<InteractKey>();
        Debug.Log(keyReference.hasKey);
    }

    //Check if player is at scene, moves to the next scene
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player") && (keyReference.hasKey == true) )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Door Check");
            keyReference.hasKey = false;
        }
    }

}
