using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnColl : MonoBehaviour
{
    // กำหนด tag ของวัตถุที่ต้องการให้ถูกทำลาย
    public string targetTag = "Target";

    // เมื่อมีการชนกับวัตถุ
    private void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าเป็นวัตถุที่ต้องการ
        if (collision.gameObject.tag == targetTag)
        {
            // ทำลายวัตถุที่ชน
            Destroy(collision.gameObject);
        }
    }
}