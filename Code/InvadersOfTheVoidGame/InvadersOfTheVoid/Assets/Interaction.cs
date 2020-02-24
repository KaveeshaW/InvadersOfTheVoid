using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour

{

    private SpriteRenderer rend;
    private Sprite leverSprite;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        leverSprite = Resources.Load<Sprite>("Medieval_props_free_12");
        //colorRed = Resources.Load<Color>("FF0000");



    } 


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interactable"))
        {
            //other.sprite = leverSprite;
            //rend.sprite = leverSprite;
            Debug.Log(other.name);
            if (Input.GetButtonDown("Fire1"))
            {
                rend.sprite = leverSprite;
                //leverSprite = Resources.Load<leverSprite>("Medieval_props_free_12");
                //rend.Sprite = new Sprite("Medieval_props_free_12");

            }
        }
    }
}
