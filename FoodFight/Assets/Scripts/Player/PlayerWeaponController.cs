using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will controll the firing of meatballs for the player
/// 
/// Author: Ben hoffman
/// </summary>
public class PlayerWeaponController : MonoBehaviour
{
    #region Fields

    public float fireRate = 1f;             // How much time is between shots
    public Transform meatballSpawnZone;     // Where we want to spawn the meatballs
    public ObjectPool meatballs;            // Object pool of meatballs

    private string fire_input_string = "Fire1";     // The name of the input button for firing
    private float _timeSinceLastShot;               // The time since we last shot

    #endregion

    /// <summary>
    /// Set our times ince last fire to the start fire rate so that 
    /// we can fire right away
    /// </summary>
    private void Start()
    {
        // Set our time since last fire to the start fire rate
        _timeSinceLastShot = fireRate;
    }

    /// <summary>
    /// Check for input from the player and see if we want to shoot
    /// </summary>
	void Update ()
    {
        // If the player wants to shoot, and we can...
		if(Input.GetButtonDown(fire_input_string) && _timeSinceLastShot <= fireRate)
        {
            // Fire a shot
            Fire();
        }
        // We are not allowed to shoot...
        else
        {
            // Add to our time since the last shot, since we haven't shot
            _timeSinceLastShot += Time.deltaTime;
        }

	}


    /// <summary>
    /// Actually fire a shot in the directoin that the player is aiming
    /// </summary>
    private void Fire()
    {
        // Get an object from teh obejct pool
        GameObject temp = meatballs.GetPooledObject();

        // Set it's rotation to where we are looking, and where we want to spawn it
        temp.transform.rotation = meatballSpawnZone.rotation;
        temp.transform.position = meatballSpawnZone.position;

        // Set it as active, which will add a force
        temp.SetActive(true);
    }
}
