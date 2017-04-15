using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will pool objects and allow you to get a pooled
/// obejct to eleimate having to instantiate objects every
/// time the player shoots
/// 
/// Author: Ben Hoffman
/// </summary>
public class ObjectPool : MonoBehaviour {

    public GameObject pooledObject;    // The object that we want to pool
    public int poolAmount = 5;         // The amount of those objects that we want to pool
    public bool willGrow;              // If this is true then we will add more meatballs when they are 

    private List<GameObject> objectPool;   // A stack of those objects 


	/// <summary>
    /// Create our object pool and instantiate the specified number of objects
    /// 
    /// Author: Ben hoffman
    /// </summary>
	void Start ()
    {
        // Instantiate the object pool
        objectPool = new List<GameObject>();

        // Create a temp gameobejct variabel to use
        GameObject temp;

        // Loop however many times we want our start size to be
        for(int i = 0; i < poolAmount; i++)
        {
            // Instantiate a new object for the pool
            temp = (GameObject)Instantiate(pooledObject);

            //Set that object as inactive
            temp.SetActive(false);

            // Push that objec to the pool
            objectPool.Add (temp);
        }    	
	}
	
	
    /// <summary>
    /// Return the first IN-ACTIVE object in the pool
    /// 
    /// If there are not active objects, then instantiate a new one
    /// and return that
    /// 
    /// Author: Ben Hoffman
    /// </summary>
    /// <returns>An inactive object that is in our pool</returns>
    public GameObject GetPooledObject()
    {
        // if there is something in our pool
        for( int i = 0; i < objectPool.Count; i++ )
        {
            // If this object is NOT active in teh hierachy
            if ( !objectPool[i].activeInHierarchy )
            {
                // return it
                return objectPool[ i ];
            }
        }

        if( willGrow )
        {
            // If we have gotten through the whole object pool and not found one, then make a new obj
            GameObject temp = ( GameObject ) Instantiate(pooledObject);

            // Add the object to our pool
            objectPool.Add(temp);
            temp.SetActive(false);
            // Return it
            return temp;
        }

        // In the end, if we do not want to grow and we have used everything,
        // then return null
        return null;
    }
}
