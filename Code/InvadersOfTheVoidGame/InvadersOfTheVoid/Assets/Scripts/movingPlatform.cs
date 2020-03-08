using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    float directionX, moveSpeed = 4f;
    bool moveRight = true;
    
    void Update () {
        if(transform.position.x > 7.5f) {
            moveRight = false;
        }
        if(transform.position.x < -4f) {
            moveRight = true;
        }
        if(moveRight) {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
