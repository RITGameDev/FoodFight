using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will disable this object after a certain number of seconds
/// have gone by.
/// 
/// AUthor: Ben Hoffman
/// </summary>
public class DisableAfterTime : MonoBehaviour {

    public float lifetime = 5f;     // How amny seconds this object will be active after awake

    /// <summary>
    /// Invoke the Destroy method after the specified lifetime
    /// </summary>
    void OnEnable()
    {
        // Destroy after 2 seconds
        Invoke("Destroy", lifetime);
    }

    /// <summary>
    /// Set as inactive in the hierachy, so that it can
    /// be pooled.
    /// </summary>
    public void Destroy()
    {
        // Play some kind of animation 

        // Set this object to in-active
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Cancel any invokes that are currently happenign
    /// </summary>
    void OnDisable()
    {
        // Cancel any invokes we may have
        CancelInvoke();
    }
}
