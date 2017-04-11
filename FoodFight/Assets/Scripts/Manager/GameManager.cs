using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will create the players of a certain type
/// based on what the players have selected on the previous screen
/// 
/// Author: Ben Hoffman
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager gameManager;      // A public static reference this so taht we can check the state anywhere

    public int countDowntime = 3;               // The number of seconds that it will take to start the game

    private GameState _currentGameState;        // The current state of the game

    public GameState CurrentGameState { get { return _currentGameState; } }

    /// <summary>
    /// Set the static reference to this game manager so that we can reference it anywhere
    /// </summary>
    private void Awake()
    {
        // Set the instance of the game amanger to make sure that it is the only one in the scene
        if (gameManager == null)
        {
            // Set the currenent referece
            gameManager = this;
        }
        else if (gameManager != this)
            Destroy(gameObject);
    }

    /// <summary>
    /// Set the current game state to the start menu on start
    /// </summary>
    private void Start()
    {
        // Set current state to the start menu
        _currentGameState = GameState.StartMenu;
    }

    /// <summary>
    /// This method can be called to set up the player optoins
    /// </summary>
    /// <param name="playerSelections">The selected player options, where the index is the player number</param>
    public void SetUpPlayers(PlayerOption[] playerSelections)
    {
        // Loop through all the player options
        for(int i = 0; i < playerSelections.Length; i++)
        {
            switch (playerSelections[i])
            {
                case (PlayerOption.AngelHair):
                    // Instantiate an angle hair pasta with that player number
                    break;
                case (PlayerOption.Linguine):
                    // Instantiate a lingunie pasta witht this player number
                    break;
                case (PlayerOption.Penne):
                    // Instantiate a penne pasta with this player number
                    break;
                case (PlayerOption.Raviolli):
                    // instnantiate a raviolli pasta with this player number
                    break;
                case (PlayerOption.Rigatoni):
                    // Instantiate a rigatoni pasta with this player number
                    break;
                default:
                    // There is something wrong
                    break;
            }
        }

        // Start a count down before startig the game


    }



    /// <summary>
    /// Wait the number of seconds for before we start the game
    /// </summary>
    /// <returns></returns>
    private IEnumerator CountDown()
    {
        // Set the current game state to the 'count down phase'
        _currentGameState = GameState.StartCountDown;

        // For as many seconds as we want for the countdown time
        for(int i = 0; i < countDowntime; i++)
        {
            // Wait 1 second
            yield return new WaitForSeconds(1f);
            // Set the text/image to the countDowntime - (i + 1)
        }

        // Set the game state to playings
        _currentGameState = GameState.Play;

    }

}
