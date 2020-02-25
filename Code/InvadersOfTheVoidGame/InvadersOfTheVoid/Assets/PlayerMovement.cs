using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 10f;
    bool jump = false;
    bool crouch = false;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //sets the horizontal speed of character 
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        //Player is jumping
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("playerJumping", true); //change character animation in animator
            jump = true;


        }

        //not needed at the moment with basic player movement
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

    //Change animation of the character when the player lands
    public void PlayerLanding()
    {
        animator.SetBool("playerJumping", false);
    }


    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}