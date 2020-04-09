using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTilemap : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //col is the player that is "colliding" with the objects: in this case its the player
        if(col.transform.CompareTag("player"))
        {
            col.transform.position = SpawnPoint.position; //Resets player to the spawnpoint (becareful of the spawn points z axis)
            col.GetComponent<Rigidbody2D>().velocity = Vector3.zero; //Resets the 2D players velocity to 0
        }
    }
}
