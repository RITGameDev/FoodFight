using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Give basic functionality to the  game, like start, quit and so on
/// 
/// Authror: Ben Hoffman
/// </summary>
public class MainMenuFunctions : MonoBehaviour {


    public Animator animControll;  // The animator controller



    /// <summary>
    /// Animate our way to the player slect
    /// </summary>
    public void ShowPlayerSelect()
    {
        // Play the animation to the player select screen
        animControll.SetTrigger("Start2Player");
    }

    /// <summary>
    /// animate from the player select screen back to the main menu
    /// </summary>
    public void PlayerMenuToMainMenu()
    {
        // Player the animatino from the player select screen to the main menu
        animControll.SetTrigger("Player2Start");
    }

    /// <summary>
    /// Quit the game
    /// 
    /// Author: Ben hoffman
    /// </summary>
	public void QuitGame()
    {
        // quit
        Application.Quit();
    }

    /// <summary>
    /// This method will  reload the current scene
    /// 
    /// Author: Ben Hoffman
    /// </summary>
    public void RestartCurrentScene()
    {
        // Restart the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevel);
    }
}
