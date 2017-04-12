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
/// Author: Ben Hoffman
/// </summary>
public class PlayerPanel : MonoBehaviour {

    public PlayerOption selectedCharacter;  // Which character we have selected.
    public UnityEngine.UI.Image placeHolderImage;   // The place holder image for the UI
    public UnityEngine.UI.Scrollbar scrollBar;

    private bool isUsed;                    // Shows whether or not this panel is being used or not
    private PlayerOptionContainer[] options;
    private int currentSelectionIndex;      // The option that we currently have selected
    private int prevIndex;
    public bool IsUsed { get { return isUsed; } set { isUsed = value; } }
	
    private void Start()
    {
        // Set the placeholder image as active
        placeHolderImage.gameObject.SetActive(true);

        // Get all the options that are available 
        options = GetComponentsInChildren<PlayerOptionContainer>();

        // Set the number of steps in the scroll bar to how many options we have
        scrollBar.numberOfSteps = options.Length;

        scrollBar.value = 1;
    }

    /// <summary>
    /// Use this with the buttons for the selection menu, 
    /// 
    /// Author: Ben Hoffman
    /// </summary>
    /// <param name="direction">Move up or down in my selcetion. True is DOWN, false is UP</param>
    public void ChangeOption(bool direction)
    {
        // Keep track of the previous index so we can change it's color back
        prevIndex = currentSelectionIndex;

        // Move my index 1 in the direction that we want to 
        if (direction)
        {
            currentSelectionIndex++;
        }
        else
        {
            currentSelectionIndex--;
        }
        
        // Make sure that we are in the right range of values
        if(currentSelectionIndex >= options.Length)
        {
            currentSelectionIndex = options.Length - 1;
            // Return out of this method so that we don't move the scroll bar anymore
        }
        else if(currentSelectionIndex < 0)
        {
            currentSelectionIndex = 0;
            // Return out of this method so that we don't move the scroll bar anymore
        }

        // Move the lsier value
        MoveSlider();
    }

    private void MoveSlider()
    {
        // Change the value of the slider
        scrollBar.value = (options.Length - currentSelectionIndex) * (1f / scrollBar.numberOfSteps);
        if (currentSelectionIndex != prevIndex)
        {

            // Highlight the currently selected index
            options[currentSelectionIndex].GetComponent<UnityEngine.UI.Image>().color = Color.blue;
            // Un-highlight the previous index
            options[prevIndex].GetComponent<UnityEngine.UI.Image>().color = Color.white;
        }

    }

    /// <summary>
    /// This will be used to select the current option 
    /// that the user is on
    /// </summary>
    public void SelectCurrrentOption()
    {
        Debug.Log("Current option:  " + options[currentSelectionIndex].character.ToString()); 

        // Play some kind of particle effect or something on that selection
    }

    /// <summary>
    /// Start using this panel
    /// </summary>
    public void Activate()
    {
        // We are using this panel now
        isUsed = true;

        // Show the player options that we have, instead of 'Press A To start'
        placeHolderImage.gameObject.SetActive(false);

        // Set our current selection to the first one
        currentSelectionIndex = 0;

        prevIndex = currentSelectionIndex;

        // Set the selection button as active
        MoveSlider();

        options[currentSelectionIndex].GetComponent<UnityEngine.UI.Image>().color = Color.blue;

    }

    /// <summary>
    /// Put the placeholder text back in front of everything,
    /// mark this object as un-used
    /// 
    ///  Author: Ben Hoffman
    /// </summary>
    public void Reset()
    {
        // We are not being used anymore
        isUsed = false;
        // Put the place holder image back up
        placeHolderImage.gameObject.SetActive(true);
    }
}
