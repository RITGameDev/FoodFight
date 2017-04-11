using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will be placed on every player panel.
/// It will pass the infomation that we gather from the player input screen
/// and pass it to the game manager on start of the game. We will need a 
/// player number for each panel, we need to bind their controller inpt to 
/// that number character. 
/// 
/// 
/// Author: Ben Hoffman
/// </summary>
public class PlayerPanel : MonoBehaviour {

    public PlayerOption selectedCharacter;  // Which character we have selected.

    private bool isUsed;                    // Shows whether or not this panel is being used or not


    public bool IsUsed { get; set; }
	

	public void SetCurrentPlayerOption()
    {

    }

    /// <summary>
    /// Start using this panel
    /// </summary>
    public void Activate()
    {
        // We are using this panel now
        isUsed = true;
        
        // Show the player options that we have, instead of 'Press A To start'
    }
}
