﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 40f;
    bool jump = false;

    float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {

            jump = true;

        }


    }

    void FixedUpdate ()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
