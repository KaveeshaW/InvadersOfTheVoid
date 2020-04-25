using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillOfHealth : MonoBehaviour
{
    public Image img;
    public enemyHealth enemy;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemyAI = GameObject.Find("enemy_AI");
        enemy = enemyAI.GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.currentHealth <= 100) {
            img.color = new Color(255f, 0f, 0f);
        }    
    }
}
