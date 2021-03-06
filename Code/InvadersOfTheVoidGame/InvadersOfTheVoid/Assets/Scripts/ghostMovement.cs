﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostMovement : MonoBehaviour
{


    public LayerMask enemyMask;
    public float speed = 7;
    public float distance = 0;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check to see if there's ground in front of us before moving forward
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 20, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * distance);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * distance, enemyMask);

        //if theres no ground, turn around. Or if I am blocked turn around
        if (!isGrounded || isBlocked)
        {
            Vector3 currentRotation = myTrans.eulerAngles;
            currentRotation.y += 180;
            myTrans.eulerAngles = currentRotation;
        }

        //always moving forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;

    }

    
}

