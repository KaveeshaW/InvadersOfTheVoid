using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform2 : MonoBehaviour
{
    float directionX;
    public float moveSpeed;
    bool moveRight = true;

    void Update () {
        if(transform.position.x > 7.5f) {
            moveRight = false;
        }
        if(transform.position.x < -3f) {
            moveRight = true;
        }
        if(moveRight) {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
    
    //when the player jumps on the moving platform, the player is now part of the platform
    private void OnCollisionEnter2D(Collision2D col) {
        if(col.transform.CompareTag("player")) {
            col.collider.transform.SetParent(transform);
        }
    }
    //when the player decides to move, they can
    private void OnCollisionExit2D(Collision2D col) {
        if(col.transform.CompareTag("player")) {
            col.collider.transform.SetParent(null);
        }
    }
}