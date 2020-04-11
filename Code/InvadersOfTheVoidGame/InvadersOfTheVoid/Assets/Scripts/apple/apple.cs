using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer appleRend;
    private PlayerHealth player;
    public int appleReward = 0;
    public GameObject myApple;
    void Start()
    {
        appleRend = myApple.GetComponent<SpriteRenderer>();
        player = GameObject.Find("player").GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("player") && (player.currentHealth <= player.maxHealth - appleReward))
        {
            player.currentHealth += appleReward;
            player.healthBar.setHealth(player.currentHealth);
            appleRend.enabled = false;
            Destroy(gameObject);
        }
    }
}
