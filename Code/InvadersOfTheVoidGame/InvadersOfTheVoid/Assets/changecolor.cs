using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecolor : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite catSprite, monsterSprite;
    private Color colorRed;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        //colorRed = Resources.Load<Color>("FF0000");



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rend.color = new Color(0f, 0f, 0f, 1f);
        }

    }
}
