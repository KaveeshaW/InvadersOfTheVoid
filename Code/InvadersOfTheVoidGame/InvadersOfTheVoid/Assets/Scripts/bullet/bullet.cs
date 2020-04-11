using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    public GameObject impact;
    void Start()
    {
      //when bullet spawns, fly forward  
      //move right according to speed
      rb.velocity = transform.right * speed;
      //enemyAnim = GameObject.Find("animator").GetComponent<enemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        //want to use the enemy takedamage function
        enemyHealth enemy =  hitInfo.GetComponent<enemyHealth>();
        //if the enemy is hit
        if(hitInfo.transform.name == "enemy_AI") {
            Impact();
            enemy.TakeDamage(damage);
        } 
        // hitting anything else does not do anything except trigger the explosion
        else {
            Impact();
        } 
    }

    void Impact() {
        //destroys the bullet
        Destroy(gameObject);
        Instantiate(impact, transform.position, transform.rotation);
    }
}
