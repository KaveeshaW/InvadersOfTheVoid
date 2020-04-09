using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineScript : MonoBehaviour
{
    public GameObject trampoline;
    public Animator animator;
    public float forceOfSpring;
    private Rigidbody2D playerRB; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.CompareTag("player")) {
            animator.SetBool("playerLanded", true);
            playerRB =  col.gameObject.GetComponent<Rigidbody2D>();
            playerRB.AddForce(new Vector2(0f, forceOfSpring));
        }
    }
    public void OnCollisionExit2D(Collision2D col) {
        if(col.transform.CompareTag("player")) {
            animator.SetBool("playerLanded", false);
        }
    }
}
