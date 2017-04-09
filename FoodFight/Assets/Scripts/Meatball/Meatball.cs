using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will make sure that the meatball does all the 
/// thigns it needs to when it is pulled out of the object
/// pool. 
/// 
/// Have a rigidbody
/// Have a mass field,
/// Add a force in the forward directoin to it's rigidbody
/// 
/// Author: Ben Hoffman
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Meatball : MonoBehaviour
{
    [SerializeField]
    private float shotForce = 5f;   // Scale of the force added to the meatball

    private Rigidbody2D rb;         // The rigidboyd 2d of this gameobejct

    /// <summary>
    /// Get a reference to the rigidboyd 2d component
    /// </summary>
    private void Awake()
    {
        // Get a reference to the rigidbody2d
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Add a force to the rigidbody on enable of the object
    /// in the forward direction. 
    /// 
    /// Author: Ben Hoffman
    /// </summary>
    private void OnEnable()
    {
        // Add a force in the forward direction 
        rb.AddForce(transform.right * shotForce, ForceMode2D.Impulse);
    }

}
