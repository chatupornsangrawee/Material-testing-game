using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionMa : MonoBehaviour
{
    public string targetTag = "Target"; // Tag ของวัตถุที่จะชน
    public GameObject objectToCheck; // วัตถุที่ต้องการเช็คว่าถูกทำลายหรือไม่
    public GameObject objectToEnable; // วัตถุที่ต้องการเปิดใช้งาน

    private void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าวัตถุที่ชนมี tag ตรงกับ targetTag หรือไม่
        if (collision.gameObject.CompareTag(targetTag))
        {
            // ตรวจสอบว่า objectToCheck ถูกทำลายหรือไม่
            if (objectToCheck == null)
            {
                // เปิดใช้งานวัตถุที่ต้องการเปิดใช้งาน
                objectToEnable.SetActive(true);
            }
        }
    }
}