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

    //public GameObject deathEffect;
    
    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.setHealth(currentHealth);
        
        if(currentHealth <= 0) {
            Die();
        }
	}
    void Die() {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        key.transform.position = new Vector3(2.13f, -7.5f, 0f);
        FindObjectOfType<LocalGameManager>().YouWin();
    }
}