using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour

{

    private SpriteRenderer rend;
    private Sprite leverSprite;
    private bool leverFrontOf;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
//leverSprite = Resources.Load<Sprite>("Medieval_props_free_12");
        leverFrontOf = false;
        //colorRed = Resources.Load<Color>("FF0000");



    } 

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && leverFrontOf ==true)
        {
            //rend.sprite = leverSprite;
            Debug.Log("Hi mom");

            //leverSprite = Resources.Load<leverSprite>("Medieval_props_free_12");
            //rend.Sprite = new Sprite("Medieval_props_free_12");

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            //other.sprite = leverSprite;
            //rend.sprite = leverSprite;
            Debug.Log(other.name);
            leverFrontOf = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            //other.sprite = leverSprite;
            //rend.sprite = leverSprite;
            //Debug.Log(other.name);
            leverFrontOf = false;

        }
    }
}
