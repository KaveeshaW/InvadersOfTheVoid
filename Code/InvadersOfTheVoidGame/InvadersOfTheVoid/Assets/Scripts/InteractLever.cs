using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLever : MonoBehaviour

{

    private SpriteRenderer rend;
    public Sprite leverSpritePulled;
    public Sprite leverSpriteUpright;

    private bool leverFrontOf;
    //public Sprite mySprite = "Medieval_props_free_12";



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        //leverSprite = Resources.Load("Medieval_props_free_12") as Sprite;
        leverFrontOf = false;
        //colorRed = Resources.Load<Color>("FF0000");



    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && leverFrontOf == true && rend.sprite == leverSpriteUpright)
        {
            //rend.sprite = leverSprite;
            Debug.Log("Hi mom from the lever");

            //leverSprite = Resources.Load<leverSprite>("Medieval_props_free_12");
            //rend.Sprite = new Sprite("Medieval_props_free_12");
            rend.sprite = leverSpritePulled;

            //this.GetComponent<SpriteRenderer>().sprite = mySprite;


        }
        else if (Input.GetButtonDown("Fire1") && leverFrontOf == true && rend.sprite == leverSpritePulled)
        {
            rend.sprite = leverSpriteUpright;

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            //other.sprite = leverSprite;
            //rend.sprite = leverSprite;
            Debug.Log(other.name);
            leverFrontOf = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            //other.sprite = leverSprite;
            //rend.sprite = leverSprite;
            //Debug.Log(other.name);
            leverFrontOf = false;

        }
    }
}
