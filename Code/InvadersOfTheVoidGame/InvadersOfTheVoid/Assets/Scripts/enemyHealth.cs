using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

	public int maxHealth = 200;
	public int currentHealth;
    public int howMuchDamage =  50;

	public HealthBar healthBar;
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
        Debug.Log("This is how much health I have left: " + currentHealth);

        if(currentHealth <= 0) {
            Die();
        }
	}
    void Die() {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<LocalGameManager>().YouWin();
    }
}