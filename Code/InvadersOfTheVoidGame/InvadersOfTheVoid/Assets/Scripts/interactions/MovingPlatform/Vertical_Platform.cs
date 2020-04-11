using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical_Platform : MonoBehaviour
{
    float directiony;
    public float moveSpeed;
    bool moveUp = true;

    void Update () {
        if(transform.position.y > 1.5f) {
            moveUp = false;
        }
        if(transform.position.y < -1.5f) {
            moveUp = true;
        }
        if(moveUp) {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
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