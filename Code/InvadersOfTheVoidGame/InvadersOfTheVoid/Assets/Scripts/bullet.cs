using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    void Start()
    {
      //when bullet spawns, fly forward  
      //move right according to speed
      rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        tilemapScript tilemap = hitInfo.GetComponent<tilemapScript>();
        enemyHealth enemy =  hitInfo.GetComponent<enemyHealth>();
        MovingPlatform2 movingPlatform = hitInfo.GetComponent<MovingPlatform2>();
        //if the enemy is there
        if(enemy != null) {
            //destroys the bullet
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        } 
        //checks to see if the tilemap exists or not
        if(tilemap != null) {
            //destroys the bullet
            Destroy(gameObject);
        } 
        if(movingPlatform != null) {
            //destroys the bullet
            Destroy(gameObject);
        } 
    }
}
