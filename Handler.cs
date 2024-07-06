using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    public GameObject popupPrefab; // กำหนด Prefab ของ Popup ที่ต้องการแสดง

    private void OnCollisionEnter(Collision collision)
    {
        // เช็คว่า GameObject ที่ชนมี TAG เป็น "Obstacle" หรือไม่
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // สร้าง Popup โดยใช้ Prefab ที่กำหนด
            GameObject popup = Instantiate(popupPrefab, collision.contacts[0].point, Quaternion.identity);
            // ตั้งค่าให้ Popup ติดตาม Object ที่ชนได้
            popup.transform.parent = collision.transform;
        }
    }
}
