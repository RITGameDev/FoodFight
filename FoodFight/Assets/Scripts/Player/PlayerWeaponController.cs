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

    private Transform rotateAround;
    private Vector3 v;

    #endregion

    /// <summary>
    /// Set our times ince last fire to the start fire rate so that 
    /// we can fire right away
    /// </summary>
    private void Start()
    {
        // Set our time since last fire to the start fire rate
        _timeSinceLastShot = fireRate;

        rotateAround = GetComponentInParent<Transform>();

        v = (meatballSpawnZone.position - rotateAround.position);

    }

    /// <summary>
    /// Check for input from the player and see if we want to shoot
    /// </summary>
	void Update ()
    {
        // Handle aiming of the weapon
        UpdateWeaponRotation();

        // If the player wants to shoot, and we can...
		if(Input.GetKeyDown(KeyCode.Q) && _timeSinceLastShot >= fireRate)
        {
            // Fire a shot
            Fire();
            // Reset the time since last shot
            _timeSinceLastShot = 0f;
        }
        // We are not allowed to shoot...
        else
        {
            // Add to our time since the last shot, since we haven't shot
            _timeSinceLastShot += Time.deltaTime;
        }
	}

    /// <summary>
    /// This will allow the user to aim around their gun using the right anaolog
    /// or the mouse movement
    /// </summary>
    private void UpdateWeaponRotation()
    {
        // Get the screen point of the center of the screeen
        Vector3 centerScreenPos = Camera.main.WorldToScreenPoint(rotateAround.position).normalized;

        // Get player inpput from the joysticks
        float yRot = Input.GetAxis("Mouse Y") * 60f;
        float xRot = Input.GetAxis("Mouse X") * 45f;

        // Create an input vector based on the playe rinput that we have
        Vector3 INPUT = new Vector3(yRot, xRot, 0F);

        // If we are not giving input then ditch this
        if (INPUT.magnitude <= 0f)
        {
            return;
        }
        // Our directino is our input minus the center of the screen poition
        Vector3 dir = INPUT - centerScreenPos;

        // Calculate the angle that we should be facing
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        // Create a quaterionon based on that angle
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        // Set our position 
        meatballSpawnZone.position = rotateAround.position + q * v;
        // Set our rotiation
        meatballSpawnZone.rotation = q;
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
