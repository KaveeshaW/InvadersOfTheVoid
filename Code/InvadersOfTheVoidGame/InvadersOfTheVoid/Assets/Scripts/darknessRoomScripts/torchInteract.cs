using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchInteract : MonoBehaviour
{

    private SpriteRenderer rend;
    SpriteRenderer torchRen;
    public Sprite torchOn;
    public Sprite torchOff;
    public SpriteMask torchMask;
    public GameObject moveableObject;
    public char direction;
    public int amountToMove;
    private bool hasTorch;
    private float initialX;
    private float initialY;
    private float currentX;
    private float currentY;
    private bool torchOnIsInitial = false;
    private bool torchOffIsInitial = false;

    public SpriteMask playerLightSource;
    public SpriteRenderer playerTorch;


    private bool torchFrontOf;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        torchFrontOf = false;
        initialX = moveableObject.transform.position.x;
        initialY = moveableObject.transform.position.y;
        currentX = initialX;
        currentY = initialY;

        if(rend.sprite == torchOn)
            torchOnIsInitial = true;
        else if(rend.sprite == torchOff)
            torchOffIsInitial = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && torchFrontOf == true && rend.sprite == torchOn && playerTorch.sortingLayerID == SortingLayer.NameToID("Default"))
        {
            //TORCH IS ON SCONCE
            //TORCH MUST BE REMOVED FROM SCONCE AND PLACED IN PLAYER'S HAND
            //TORCH IN PLAYER'S HAND MUST APPEAR AND LIGHT SOURCE MUST BE MOVED FORWARD
            Debug.Log("Hi from the torchOn");

            //Remove torch from sconce
            rend.sprite = torchOff;
            torchMask.frontSortingLayerID = SortingLayer.NameToID("Default");
            //Place torch in player's hand
            playerTorch.sortingLayerID = SortingLayer.NameToID("Darkness");
            //Light source moved forward
            playerLightSource.frontSortingLayerID = SortingLayer.NameToID("Darkness");

            if (torchOnIsInitial)
                moveObject();
            else
                returnObjectToInitial();
            //torchMask.sortingLayerName = "Default";

        }
        else if (Input.GetButtonDown("Fire1") && torchFrontOf == true && rend.sprite == torchOff && playerTorch.sortingLayerID == SortingLayer.NameToID("Darkness"))
        {
            rend.sprite = torchOn;
            torchMask.frontSortingLayerID = SortingLayer.NameToID("Darkness");
            //Remove torch from player's hand
            playerTorch.sortingLayerID = SortingLayer.NameToID("Default");
            //Light source moved behind darkness layer
            playerLightSource.frontSortingLayerID = SortingLayer.NameToID("Default");

            if (torchOffIsInitial)
                moveObject();
            else
                returnObjectToInitial();

            //returnObjectToInitial();

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log(other.name);
            torchFrontOf = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            torchFrontOf = false;
        }
    }

    void moveObject()
    {
        if(direction == 'd')
        {
            float newY = currentY - (amountToMove);
            Vector2 pos = new Vector2(currentX, newY);
            moveableObject.transform.position = pos;
        }
        else if (direction == 'u')
        {
            float newY = currentY + (amountToMove);
            Vector2 pos = new Vector2(currentX, newY);
            moveableObject.transform.position = pos;
        }
        else if (direction == 'r')
        {
            float newX = currentX + (amountToMove);
            Vector2 pos = new Vector2(newX, currentY);
            moveableObject.transform.position = pos;
        }
    }

    void returnObjectToInitial()
    {
        Vector2 pos = new Vector2(initialX, initialY);
        moveableObject.transform.position = pos;
    }
}