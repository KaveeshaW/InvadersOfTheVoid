using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//respawns player to a certain location
public class respawnPlayer : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("player"))
        {
            col.transform.position = SpawnPoint.position;
        }
    }
}
