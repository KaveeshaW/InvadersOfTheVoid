using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour

{

    private SpriteRenderer rend;
    private Sprite catSprite, monsterSprite;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            Debug.Log(other.name);
            if (Input.GetButtonDown("fire1"))
            {

            }
        }
    }
}
