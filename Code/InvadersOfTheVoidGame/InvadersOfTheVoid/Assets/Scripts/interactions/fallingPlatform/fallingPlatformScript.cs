using System.Collections;
 using UnityEngine;
 
 public class fallingPlatformScript : MonoBehaviour
 {
     public float fallDelay = 2.0f;
     Rigidbody2D rb;

     public Animator animator;
     void Start () {
         rb = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
     }
     void OnCollisionEnter2D(Collision2D col)
     {
         //could use col.gameObject.name.Equals
         if (col.transform.CompareTag("player"))
         {
             //drop in half a second
             Invoke("DropPlatform", 0.5f);
             animator.SetBool("playerOnTop", true);
             //destroy in 2 seconds
             Destroy(gameObject, 2f);
         }
     }
 
     void DropPlatform() {
         //the platform will respond to the player and start falling
         rb.isKinematic = false;
     }
 }