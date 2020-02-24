using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//changes the pixel art of the enemy to face the other way if they are using pathfinding
public class enemyGraphics : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-4f, 4f, 4f);
        } else if(aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(4f, 4f, 4f);
        }
    }
}
