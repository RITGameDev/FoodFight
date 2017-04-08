using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will allow for some basic 2D player movement
/// using a rigidbody2d componenet. They will have the ability to
/// jump, and move left and right
/// 
/// Author: Ben Hoffman
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    #region Fields

    [SerializeField]
    private float speed = 10f;   // Flot of the player movement speed. Default is 10
    [SerializeField]
    private Vector2 jumpForce;    // How much force will be added when we are jumping. Default is 0, 10
    [SerializeField]
    private float jumpLimit = 0.3f; // How far off the ground we need to be in order to jump again. Default is 0.3

    private Rigidbody2D rb; // Store a reference to the Rigidbody2D componeent

    private string horizontal_input_string = "Horizontal";  // The horizontal input axis
    private string vertical_input_string = "Vertical";      // The vertical input axis
    private string jump_input_string = "Jump";                  // The jump iunput axis
        
    private RaycastHit2D _jumpCheck_output; // The ray hit information about if we can jump or not
    private Vector3 _rayOffset;             // The size of the collider so that we can offset it when we shoot a ray

    #endregion

    /// <summary>
    /// Get the player's rigidbody component and initalize the ray
    /// </summary>
    void Start ()
    {
        // Get the ridid body componenet
        rb = GetComponent<Rigidbody2D>();

        // Get the colliders size so that we know it for shooting rays
        _rayOffset.y = -GetComponent<CapsuleCollider2D>().size.y;
	}
	
    /// <summary>
    /// This method will handle things that the player will want instant 
    /// feedback for, like jumping. 
    /// </summary>
    void Update()
    {
        // If the player presses the jump input, and we are not already in the air
        if(Input.GetButtonDown(jump_input_string))
        {
            // Create a ray and store the results in a field           
            _jumpCheck_output = Physics2D.Raycast(transform.position + _rayOffset, -Vector2.up,  jumpLimit);

            // If we are hitting something (we are on the ground)
            if (_jumpCheck_output.collider != null)
            {
                // Add the jump force to our rigidbody with the impulse fassion
                rb.AddForce(jumpForce, ForceMode2D.Impulse);
            }

        }
    }

	/// <summary>
    /// Calculate player movement based on input from the 
    /// proper horizontal and vertical axises.
    /// </summary>
	void FixedUpdate ()
    {
        // Get the horizontal input that will be between 0.0 and 1.0
        float moveHorizontal = Input.GetAxis(horizontal_input_string);

        // Get the vertical input that will be between 0.0 and 1.0
        float moveVertical = Input.GetAxis(vertical_input_string);

        // Create a vector2 variable based off of those input variables
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Add a force to the rigidbody based on our player movement
        rb.AddForce(movement * speed);
    }
}
