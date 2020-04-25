using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
   public Transform firePoint;
   public GameObject bulletPrefab;

    //specifies the cool down of the player bullet (how long to wait before firing)
   public float coolDown = 2;
   //gets the time since bullet
   float timeSinceBullet;

    void Start() {
        timeSinceBullet = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        //have to wait until you can fire again
        if(Input.GetButtonDown("Fire2") && Time.time - timeSinceBullet > coolDown) {
            //keeps updating the time so that 
            timeSinceBullet = Time.time;
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //shooting logic
    }
}
