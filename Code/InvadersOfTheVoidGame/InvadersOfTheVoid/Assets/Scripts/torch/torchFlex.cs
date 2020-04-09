using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchFlex : MonoBehaviour
{

    bool isLeft, isRight; //lets us know which way the torch is facing
    bool CPUprotector; //makes sure an infintesmal amount of worker threads aren't being created, preventing the CPU from melting.

    // Start is called before the first frame update
    void Start()
    {
        CPUprotector = false;
        isLeft = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (CPUprotector == false)
        {
            StartCoroutine(workerThread());
        }

    }

    //This is the worker thread that updates the torch sprite
    private IEnumerator workerThread()
    {
        // process pre-yield
        CPUprotector = true;
        if (isLeft == true)
        {
            Vector3 sca = new Vector2(-1, 1);
            transform.localScale = sca;
            isLeft = false;
            isRight = true;
        }
        else if (isRight == true)
        {
            Vector3 sca = new Vector2(1, 1);
            transform.localScale = sca;
            isLeft = true;
            isRight = false;
        }
        yield return new WaitForSeconds(.25f);
        // process post-yield
        CPUprotector = false;
    }
}
