using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public GameObject objectB;

    void Update()
    {
        // เช็คการกดปุ่ม H
        if (Input.GetKeyDown(KeyCode.H))
        {
            // สลับสถานะการเปิด/ปิดของ objectB
            objectB.SetActive(!objectB.activeSelf);
        }
    }
}