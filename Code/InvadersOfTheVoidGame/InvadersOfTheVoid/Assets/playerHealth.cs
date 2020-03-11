using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public static float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount <= 0) {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name.Equals("enemy")) {
            healthAmount -= 0.1f;
        }
    }
}
