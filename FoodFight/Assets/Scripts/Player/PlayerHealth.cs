using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

// Caleb Katzenstein
// Handles player health
public class PlayerHealth : MonoBehaviour 
{
	// the health when first starting
	public float startingHealth;
	// stores the health at any given moment
	private float currentHealth;

	/// <summary>
    /// Set the current health to the start health
    /// </summary>
	void Start () 
	{
		currentHealth = startingHealth;
	}
	
	// if player collides with a meatball, this loses health
	private void OnCollisionEnter2D(Collision2D other)
	{
        // If we collide with a meatball...
		if (other.gameObject.CompareTag ("Meatball")) 
		{
            // Take damage based on the mass of the meatball
			currentHealth -= other.gameObject.GetComponent<Rigidbody2D>().mass;

			// prints current health
			print (currentHealth);          

            // If the player has a health of less than 0...
			if (currentHealth <= 0) 
			{
                // Handle player death
                Die();
			}
		}
	}

    /// <summary>
    /// Handles player death
    /// </summary>
    private void Die()
    {
        Debug.Log(this.name + " is dead!");

        // Tell the game manager that this player has died
    }
}
