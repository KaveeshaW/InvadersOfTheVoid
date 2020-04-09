using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCheck : MonoBehaviour
{
    //Reference gives the ability to use the bool between scripts
    private InteractKey keyReference;  
    Scene scene;

    public void Start()
    {
            // Return the current Active Scene in order to get the current Scene name.
        scene = SceneManager.GetActiveScene();
        keyReference = GameObject.Find("key").GetComponent<InteractKey>();
    }

    //Check if player is at scene, moves to the next scene
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player") && (keyReference.hasKey == true) )
        {
            if(scene.name == "kaveesha") {
                SceneManager.LoadScene("thanksForPlaying");
            }
            if(scene.name == "Room1_Latest") {
                SceneManager.LoadScene("Room2_TBC");
            }
            keyReference.hasKey = false;
        }
    }

}
