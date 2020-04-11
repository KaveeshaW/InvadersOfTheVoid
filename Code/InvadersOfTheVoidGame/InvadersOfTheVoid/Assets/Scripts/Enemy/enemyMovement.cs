using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls back and forth movement of enemy
public class enemyMovement : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 7;
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
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .05f, enemyMask);

        //need to change the z axis so that the sprite is flipped
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        //if theres no ground, turn around. Or if I am blocked turn around
        if (!isGrounded || isBlocked)
        {
            transform.localScale = flipped;
            //need to rotate the sprite as well
            transform.Rotate(0f, 180f, 0f);
        }

        //always moving forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;

    }
}
