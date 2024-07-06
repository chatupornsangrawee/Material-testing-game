using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivato : MonoBehaviour
{
    // Drag and drop the game objects in the Unity Inspector
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject objectD;

    void Update()
    {
        // Check if all objects A, B, and C are active
        if (objectA.activeInHierarchy && objectB.activeInHierarchy && objectC.activeInHierarchy)
        {
            // Activate object D if it's not already active
            if (!objectD.activeInHierarchy)
            {
                objectD.SetActive(true);
                Debug.Log("Object D is now active.");
            }
        }
        else
        {
            // Optionally, deactivate object D if not all are active
            if (objectD.activeInHierarchy)
            {
                objectD.SetActive(false);
                Debug.Log("Object D is now inactive.");
            }
        }
    }
}