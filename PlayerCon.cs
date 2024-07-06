using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วของการเคลื่อนที่
    public float rotateSpeed = 100f; // ความเร็วในการหมุนมุมกล้อง

    private Rigidbody rb;
    private bool isRightClickHold = false; // ตรวจสอบว่าคลิกขวาค้างหรือไม่
    private Transform camTransform; // Transform ของกล้อง

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // ล็อก cursor ให้ไม่เคลื่อนไหว
        Cursor.visible = false; // ทำให้ cursor ไม่แสดงผลบนหน้าจอเริ่มต้น

        // ดึง Transform ของกล้องที่อยู่ภายใต้ GameObject นี้
        camTransform = GetComponentInChildren<Camera>().transform;
    }

    void Update()
    {
        // รับค่า input จากแกนแนวนอนและแนวตั้ง
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // กำหนดเวกเตอร์ทิศทางการเคลื่อนที่
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // ใช้ Rigidbody เพื่อเคลื่อนที่ตามทิศทางที่กำหนด
        rb.velocity = transform.forward * moveVertical * moveSpeed;

        // เคลื่อนที่ข้างซ้ายและข้างขวา
        rb.velocity += transform.right * moveHorizontal * moveSpeed;

        // ตรวจสอบ input การคลิกขวา
        if (Input.GetMouseButtonDown(1))
        {
            if (isRightClickHold)
            {
                isRightClickHold = false; // เปลี่ยนสถานะการล็อคเมาส์
                Cursor.lockState = CursorLockMode.None; // ปลดล็อก cursor
                Cursor.visible = true; // ทำให้ cursor แสดงผลบนหน้าจออีกครั้ง
            }
            else
            {
                isRightClickHold = true;
                Cursor.lockState = CursorLockMode.Locked; // ล็อก cursor ให้ไม่เคลื่อนไหว
                Cursor.visible = false; // ทำให้ cursor ไม่แสดงผลบนหน้าจอ
            }
        }

        // หมุนมุมกล้องเมื่อคลิกขวาค้าง
        if (isRightClickHold)
        {
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

            // หมุนมุมกล้องตามแกน Y โดยไม่จำกัดมุม
            transform.Rotate(Vector3.up, mouseX);
            // หมุนมุมกล้องตามแกน X โดยไม่จำกัดมุม
            camTransform.Rotate(Vector3.left, mouseY);
        }
    }
}