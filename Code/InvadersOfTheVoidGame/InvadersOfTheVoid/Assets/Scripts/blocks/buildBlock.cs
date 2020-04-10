using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBlock : MonoBehaviour
{
    //reference blockSys
  private blockSys blockSystem;

  //hold data of current block
  private int currentBlockID = 0;
  private Block currentBlock;

  //variables for the block template
  private GameObject blockTemplate;
  private SpriteRenderer rend;

  // set build mode on/off
  private bool buildMode = false;
  private bool buildBlocked = false;

 // variable used to adjust size of placement box into tiles
 [SerializeField]  
 private float blockSizeMod;
// variable used to adjust casting
 [SerializeField]
 private LayerMask builtBox;

 [SerializeField]
 private LayerMask deleteBlocksLayer;

  private void Awake(){
        blockSystem = GetComponent<blockSys>();
  }

  private void Update(){
      if(Input.GetKeyDown("f")){
          buildMode = !buildMode;
            // safety to avoid duplicates. If current already exists destroy it
          if(blockTemplate != null){
              Destroy(blockTemplate);
          }
           
          if (currentBlock == null){
              if(blockSystem.newBlock != null){
                   currentBlock = blockSystem.newBlock;
              }
          }
      

      if(buildMode){
          // create a new object for the block template
          blockTemplate = new GameObject("CurrBlockTemplate");

          // store sprite renderer on template object
          rend = blockTemplate.AddComponent<SpriteRenderer>();
          // set sprite on template object
          rend.sprite = currentBlock.blockSprite;
      }
    }
    // will allow you to show block with mouse if blocktemplate is made and buildmode is on
    if(buildMode && blockTemplate != null ){
        float newPosX = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / blockSizeMod) * blockSizeMod;
        float newPosY = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y / blockSizeMod) * blockSizeMod;
        blockTemplate.transform.position = new Vector2(newPosX, newPosY);
    
        RaycastHit2D rayHit;

        rayHit = Physics2D.Raycast(blockTemplate.transform.position, Vector2.zero, Mathf.Infinity, builtBox);
        
        if(rayHit.collider != null){
            buildBlocked = true;
        }
        else{
            buildBlocked = false; 
        }
        // change the color of sprite to indicate that you can't place block there
        if(buildBlocked){
            rend.color = new Color(1f, 0f, 0f, 1f);
        }
        else{
            rend.color = new Color(1f,1f,1f,1f);
        }

        // build and display box when left mouse button is clicked
        if(Input.GetMouseButtonDown(0) && buildBlocked == false){
            // create block 
            GameObject newBlock2= new GameObject(currentBlock.blockName); 
            //update position to where the template object is 
            newBlock2.transform.position = blockTemplate.transform.position;
            SpriteRenderer newRender = newBlock2.AddComponent<SpriteRenderer>();
            newRender.sprite = currentBlock.blockSprite;

             // ensure player can't walk in front of blocks
            if(currentBlock.isSolid == true){   
                newBlock2.AddComponent<BoxCollider2D>();
                newBlock2.layer = 10;
                newRender.sortingOrder = -10;
            }
        }

        // destroy blocks when right mouse button is clicked
        if(Input.GetMouseButtonDown(1) && blockTemplate != null){
            Debug.Log("Right-click registered");
            RaycastHit2D destroyBlock = Physics2D.Raycast(blockTemplate.transform.position, Vector2.zero, Mathf.Infinity, deleteBlocksLayer);

            if(destroyBlock.collider != null){
                Debug.Log("About to delete block ");
                Destroy(destroyBlock.collider.gameObject);
            }
      
        }

 

    }
  }

}
