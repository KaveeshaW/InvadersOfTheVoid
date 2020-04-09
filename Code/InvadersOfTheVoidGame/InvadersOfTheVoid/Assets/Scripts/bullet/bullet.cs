﻿using System.Collections;
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
        //getting all of the different components of the scene that the bullet could touch
        tilemapScript tilemap = hitInfo.GetComponent<tilemapScript>();
        enemyHealth enemy =  hitInfo.GetComponent<enemyHealth>();
        MovingPlatform2 movingPlatform = hitInfo.GetComponent<MovingPlatform2>();
        fallingPlatformScript fallingPlatform = hitInfo.GetComponent<fallingPlatformScript>();
        trampolineScript trampoline = hitInfo.GetComponent<trampolineScript>();
        //if the enemy is there
        if(enemy != null) {
            //destroys the bullet
            Destroy(gameObject);
            enemy.TakeDamage(damage);
        } 
        //checks to see if the tilemap exists or not
        if(tilemap != null || movingPlatform != null || fallingPlatform != null || trampoline != null) {
            //destroys the bullet
            Destroy(gameObject);
        } 
    }
}