using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
// Caleb Katzenstein
// Handles player health
public class PlayerHealth : MonoBehaviour 
{
	// the health when first starting
	int startingHealth;
	// stores the health at any given moment
	int currentHealth;
	// Use this for initialization
	void Start () 
	{
		startingHealth = 100;
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	// if player collides with a meatball, this loses health
	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Meatball")) 
		{
			currentHealth -= 20;
			// prints current health
			print (currentHealth);
			if (currentHealth <= 0) 
			{
				// restarts the program
				EditorSceneManager.LoadSceneAsync (EditorSceneManager.GetActiveScene().buildIndex);
			}
		}
	}
}
