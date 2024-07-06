using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obje : MonoBehaviour
{
    // Drag and drop the objects from the inspector
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;

    // Update is called once per frame
    void Update()
    {
        // Check if objectA is active
        if (objectA.activeSelf)
        {
            // Activate objectB and deactivate objectC
            objectB.SetActive(true);
            objectC.SetActive(false);
        }
    }
}