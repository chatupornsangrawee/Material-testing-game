using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCheck : MonoBehaviour
{
    public GameObject objectA; // กำหนดวัตถุ A ใน Inspector
    public GameObject objectB; // กำหนดวัตถุ B ใน Inspector

    private void Update()
    {
        // ตรวจสอบว่าวัตถุ A ถูกทำลายหรือยัง
        if (objectA == null)
        {
            // ถ้าถูกทำลายแล้ว ให้เรียกใช้ฟังก์ชัน ActivateObjectB() เพื่อให้วัตถุ B ทำงาน
            ActivateObjectB();
        }
    }

    // ฟังก์ชันสำหรับทำงานของวัตถุ B
    private void ActivateObjectB()
    {
        if (objectB != null)
        {
            // เปิดใช้งานวัตถุ B
            objectB.SetActive(true);
            // สามารถเรียกใช้โค้ดอื่น ๆ ที่เกี่ยวข้องกับการเปิดใช้งานวัตถุ B ได้ที่นี่
        }
        else
        {
            Debug.LogWarning("Object B is not assigned!"); // แจ้งเตือนในกรณีที่ไม่ได้กำหนดวัตถุ B ใน Inspector
        }
    }
}