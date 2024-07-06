using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDest : MonoBehaviour
{
    public GameObject objectA; // วัตถุ A ที่ต้องการตรวจสอบ
    public GameObject objectB; // วัตถุ B ที่ต้องการทำลาย

    private bool isDestroyed = false; // ตัวแปรเก็บสถานะการทำลายของวัตถุ A

    void Update()
    {
        // ตรวจสอบว่าวัตถุ A ถูกทำลายไปแล้วหรือยัง
        if (objectA == null && !isDestroyed)
        {
            // ถ้าวัตถุ A ถูกทำลายไปแล้ว ทำลายวัตถุ B
            Destroy(objectB);
            isDestroyed = true; // เซ็ตให้สถานะการทำลายของวัตถุ A เป็น true เพื่อป้องกันการทำลายซ้ำ
        }
    }
}