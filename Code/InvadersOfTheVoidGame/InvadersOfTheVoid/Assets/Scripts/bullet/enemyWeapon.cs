using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeapon : MonoBehaviour
{
   public Transform firePoint;
   public GameObject bulletPrefab;
   
   //specifies the cool down of the player bullet (how long to wait before firing)
   public float coolDown = 3;
   //gets the time since bullet
   float timeSinceBullet;
   public GameObject impactEffect;
   public LineRenderer lineRenderer;
   public enemyHealth enemyHealth;

    void Start() {
        //sets the timeSinceBullet equal to current time
        timeSinceBullet = Time.time;
        
        //used to get the enemy health
        GameObject enemyAI = GameObject.Find("enemy_AI");
        enemyHealth = enemyAI.GetComponent<enemyHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        //have to wait until you can fire again
        if(Time.time - timeSinceBullet > coolDown && enemyHealth.currentHealth <= 100) {
            timeSinceBullet = Time.time;
            StartCoroutine(Shoot());
        }
    }

    //IEnumerator allows us to pause frames
    IEnumerator Shoot() {
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //send a ray in a point in a direction
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right * -1);
        if(hitInfo) {
             PlayerHealth player =hitInfo.transform.GetComponent<PlayerHealth>();
             if(player != null) {
                 player.TakeDamage(10);
             }
             //Quaternion.identity is just no rotation
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            //go from point shot to point hit
            //0 is start position, 1 is end position
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        // //goes infinitely in space
        // else {
        //     lineRenderer.SetPosition(0, firePoint.position);
        //     //the bat shoots from the left so I multiply by 100
        //     //shifting the ray 100 units forward    
        //     lineRenderer.SetPosition(1, firePoint.position + firePoint.right * -100);
        // }
        //turns the line on and off
        lineRenderer.enabled = true;

        //wait one frame
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

    }
}
