using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public GameObject targetObject; // วัตถุที่มี Text Mesh
    private TextMesh textMeshComponent; // คอมโพเนนต์ Text Mesh
    public GameObject object1; 
    public GameObject object2;
    void Start()
    {
        // ตรวจสอบว่ามีคอมโพเนนต์ Text Mesh ในวัตถุ targetObject หรือไม่
        textMeshComponent = targetObject.GetComponent<TextMesh>();
        if (textMeshComponent == null)
        {
            Debug.LogError("Target object does not have a TextMesh component!");
            return;
        }

        // เริ่มต้นนับถอยหลังเมื่อเริ่มเกม
        StartCountdown();
    }

    void StartCountdown()
    {
        // ตั้งเวลาในการเรียกใช้เมธอด CountDown ทุกๆ 1 วินาที
        InvokeRepeating("CountDown", 0, 1);
    }

    void CountDown()
    {
        // ส่งข้อความไปยัง Text Mesh ของวัตถุ targetObject
        textMeshComponent.text = countdownValue.ToString();

        // ลดค่า countdownValue ลงทีละ 1
        countdownValue--;

        // เมื่อ countdownValue เป็น 0 ให้หยุดนับถอยหลัง
        if (countdownValue < 0)
        {
            // หยุดการเรียกใช้เมธอด CountDown
            CancelInvoke("CountDown");

            // ตัวอย่างการทำสิ่งอื่นๆ เมื่อนับถอยหลังเสร็จสิ้น
            Debug.Log("Countdown Finished!");

            Destroy(object1); 
            object2.SetActive(true);

        }
    }

    private int countdownValue = 10; // ค่าที่ใช้ในการนับถอยหลัง
}
