using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKey : MonoBehaviour
{
    private SpriteRenderer keyRend;
    public GameObject key;
    public bool hasKey = false;

    void Start()
    {
        keyRend = key.GetComponent<SpriteRenderer>();
    }
    //if the player is near the key, it is picked up
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            hasKey = true;
            keyRend.enabled = false;
        }
    }

    public void resetKey()
    {
        hasKey = false;
        keyRend.enabled = true;
    }
}
