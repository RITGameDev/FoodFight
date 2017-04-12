using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will hold an array of player pannel objects that are all
/// 'inactive' to start.
/// 
/// Author: Ben Hoffman
/// </summary>
public class PlayerSelectScreen : MonoBehaviour {

    public PlayerPanel[] panels;       // The panels tha we have for the players to choose from

	/// <summary>
    /// Get the panel components on this game object
    /// </summary>
	void Start ()
    {
        // Get the player panel componenets
        panels = GetComponentsInChildren<PlayerPanel>();
	}
	
	/// <summary>
    /// Listen for player input and determine if we need to mark a panel
    /// as active or not
    /// 
    /// Author: Ben Hoffman
    /// </summary>
	void Update () 
    {
        // If a player hits the P key, then make this object active
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Find the first UN-USED panel in our array
            for(int i = 0; i < panels.Length; i++)
            {
                // If this panel is not being used already...
                if (!panels[i].IsUsed)
                {
                    // Activate that panel
                    panels[i].Activate();
                    return;
                }

            }

            // There are no more player objects to active
            Debug.Log("There are no more player spots available!");
        }
    }

    /// <summary>
    ///  This will give all the info we have on the player options to the game
    ///  controller, so that we can instantiate all of them
    ///  
    /// Author: Ben Hoffman
    /// </summary>
    public void StartGame()
    {


        //GameManager.gameManager.SetUpPlayers();
    }
}
