using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

	public int maxHealth = 200;
	public int currentHealth;
    public int howMuchDamage =  50;

	public HealthBar healthBar;
    public GameObject key;

    public Animator animator;
    public Rigidbody2D rb;
    public GameObject deathEffect;

    //will be used to indicate a different phase
    private SpriteRenderer rend;
    //private Color color;
    //private fillOfHealth healthBarColor;
    public EnemyAI enemy;
    
    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

        //used to get the enemy speed
        GameObject enemyAI = GameObject.Find("enemy_AI");
        enemy = enemyAI.GetComponent<EnemyAI>();
        //healthBarColor = GameObject.Find("img").GetComponent<fillOfHealth>();
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.setHealth(currentHealth);
        
        animator.Play("bat_hit");
        //slows down the bat when hit
        rb.velocity = rb.velocity * 0.7f;
        //second phase
        if(currentHealth <= 100) {
            rend.color = new Color(100f, 0f, 0f);
            enemy.speed = 700f;
            //healthBarColor.color = new Color(100f, 0f, 0f);
        }
        if(currentHealth <= 0) {
            Die();
        }
	}
    void Die() {
        //quaternion identity sets the rotation to null
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //puts the key where the player can access it
        key.transform.position = new Vector3(-11.13f, -7.5f, 0f);
    }
}