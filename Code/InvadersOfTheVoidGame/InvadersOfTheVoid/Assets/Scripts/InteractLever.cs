using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLever : MonoBehaviour

{

    private SpriteRenderer rend;
    SpriteRenderer chestRend;
    public Sprite leverSpritePulled;
    public Sprite leverSpriteUpright;
    public Sprite chestClosed;
    public Sprite chestOpen;
    public GameObject movableLadder;
    public GameObject chest;
    public GameObject key;


    private bool leverFrontOf;
    //public Sprite mySprite = "Medieval_props_free_12";
    //Vector3 pos = transform.position;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        //leverSprite = Resources.Load("Medieval_props_free_12") as Sprite;
        leverFrontOf = false;
        //colorRed = Resources.Load<Color>("FF0000");
        //pos.y = -4.58f;




    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && leverFrontOf == true && rend.sprite == leverSpriteUpright)
        {
            //LEVER IS PULLED DOWN
            //KEY SHOULD BE REVEALED
            //LADDER TO DOOR SHOULD GO DOWN
            Debug.Log("Hi from the lever");

            //changes sprite of lever to that in the pulled down position
            rend.sprite = leverSpritePulled;
            //adjusts scale and position of lever sprite so it looks consistent
            Vector3 pos = new Vector3(1.346f, -4.56f, 0.0f);
            Vector3 sca = new Vector3(1.342374f, 1.30707f, 1f);
            transform.position = pos;
            transform.localScale = sca;

            //moves ladder down
            movableLadder.transform.position = new Vector3(6.481f, -8.16f, 0.0f);

            //exposes key if it isn't in inventory
            key.transform.position = new Vector3(-4.4f, -4.65f, 0f);
            chestRend = chest.GetComponent<SpriteRenderer>();
            chestRend.sprite = chestOpen;






            //this.GetComponent<SpriteRenderer>().sprite = mySprite;


        }
        else if (Input.GetButtonDown("Fire1") && leverFrontOf == true && rend.sprite == leverSpritePulled)
        {
            rend.sprite = leverSpriteUpright;
            Vector3 pos = new Vector3(1.5f, -4.46f, 0.0f);
            Vector3 sca = new Vector3(1.2907f, 1.2907f, 1.2907f);


            transform.position = pos;
            transform.localScale = sca;

            //moves ladder up
            movableLadder.transform.position = new Vector3(6.481f, -5.49f, 0.0f);

            //hides key in chest
            key.transform.position = new Vector3(-4.4f, -6.65f, 0f);
            chestRend = chest.GetComponent<SpriteRenderer>();
            chestRend.sprite = chestClosed;

            //6.481  -5.49


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
