using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockSys : MonoBehaviour
{
  [SerializeField]
  private Sprite block;
  

  public Block newBlock;

    private void Awake(){
        int newID = 0;
        newBlock  = new Block(newID, "woodenBox", block, true);
        print("Solid Block Created:" + newID + " " + "wooden");
    }
}

public class Block {
    public int blockID;
    public string blockName;
    public Sprite blockSprite;
    public bool isSolid;

    public Block(int id, string name, Sprite mySprite, bool isSolid){
            Debug.Log("yo");
            blockID = id;
            blockName = name;
            blockSprite = mySprite;
            this.isSolid = isSolid;

    }

}
