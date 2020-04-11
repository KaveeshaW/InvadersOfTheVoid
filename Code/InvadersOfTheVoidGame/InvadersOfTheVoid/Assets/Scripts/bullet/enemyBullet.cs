using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 10;
    public GameObject impact;
    void Start()
    {
      //when bullet spawns, fly forward  
      //move left according to speed
      rb.velocity = transform.right *-1 * speed;
      //enemyAnim = GameObject.Find("animator").GetComponent<enemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        //getting all of the different components of the scene that the bullet could touch
        PlayerHealth player =  hitInfo.GetComponent<PlayerHealth>();
        //if the enemy is there
        if(player != null) {
           
            Impact();
            player.TakeDamage(damage);
            //enemyAnim.animator.SetBool("batHit", false);
        } 
        //checks to see if the tilemap exists or not
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
