using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //update the speed for animation movements
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jumping", true); //set the jumping to true for animation change
            jump = true;

        }

        //not needed at the moment
        /*
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
        */
    }

    public void PlayerLanding()
    {
        animator.SetBool("Jumping", false); //Change animation back
    }
    
    void FixedUpdate ()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
