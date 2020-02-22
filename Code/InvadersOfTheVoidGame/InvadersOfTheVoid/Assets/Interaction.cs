using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            Debug.Log(other.name);
            if (Input.GetButtonDown("fire1"))
            {

                jump = true;

            }
        }
    }
}
