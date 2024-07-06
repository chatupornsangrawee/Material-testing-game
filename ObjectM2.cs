using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectM2 : MonoBehaviour
{
    public GameObject objectToDisable; // วัตถุที่ต้องการปิดการใช้งาน
    public GameObject objectToEnable; // วัตถุที่ต้องการเปิดใช้งาน

    private void Update()
    {
        // ตรวจสอบการกดปุ่ม Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // ปิดการใช้งาน objectToDisable
            objectToDisable.SetActive(false);
            
            // เปิดการใช้งาน objectToEnable
            objectToEnable.SetActive(true);
        }
    }
}