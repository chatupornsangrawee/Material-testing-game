using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOb : MonoBehaviour
{
    public string tagToCheck = "SET"; // ตัวแปรเก็บชื่อ TAG ที่ต้องการเช็ค

    public GameObject objectToActivate; // ตัวแปร public เพื่อเก็บวัตถุที่ต้องการเปิดใช้งาน

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck)) // เช็คว่าวัตถุที่ชนมี TAG เท่ากับ tagToCheck หรือไม่
        {
            objectToActivate.SetActive(true); // เปิดใช้งานวัตถุที่กำหนดในตัวแปร objectToActivate
        }
    }
}