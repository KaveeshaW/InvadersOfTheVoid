using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;
  public int howMuchDamage =  20;
  Renderer renderer;
  Color color;
  public GameObject player;
  public bool invincible = false;
	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);
      renderer = GetComponent<Renderer>();
      color = renderer.material.color;
    }

    // Update is called once per frame
    // void Update()
    // {
		// if (Input.GetKeyDown(KeyCode.Space))
		// {
		// 	TakeDamage(damage);
		// }
        
    // }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("enemy"))
        {
            TakeDamage(howMuchDamage);
        }
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.setHealth(currentHealth);
    if(currentHealth > 0) {
      //used so that you can pause the routine for a certain amount of time
      //used for a certain amount of frames
      StartCoroutine("Invulnerability");
    }
    if(currentHealth <= 0) {
      SceneManager.LoadScene("gameOver");
    }
	}

  public IEnumerator Invulnerability()
	{
    invincible = true;
    Debug.Log("In here!!!!!!!!!!!");
    //the numbers in the function mean which layers should be ignored
    //layer 8 is the player, layer 9 is the enemy
		Physics2D.IgnoreLayerCollision (8, 9, true);
    //sets the player transparent to indicate that you are invulnerable
    //a is the alpha component of the color, either transparent or opaque
		color.a = 0.5f;
		renderer.material.color = color;
		yield return new WaitForSeconds (3f);
    //not invulnerable any more
		Physics2D.IgnoreLayerCollision (8, 9, false);
    invincible = false;
		color.a = 1f;
		renderer.material.color = color;
	}
}