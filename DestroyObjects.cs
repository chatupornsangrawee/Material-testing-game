using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public GameObject[] objectsToDestroy; // กำหนดวัตถุที่ต้องการทำลายใน Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            DestroyObjectsInArray();
        }
    }

    void DestroyObjectsInArray()
    {
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj); // ทำลายวัตถุในอาร์เรย์ objectsToDestroy
        }
    }
}