using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContro : MonoBehaviour
{
    public float speed = 5.0f; // ความเร็วของตัวละคร

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // รับข้อมูล Input จากผู้เล่น
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // กำหนดทิศทางการเคลื่อนที่ของตัวละคร
        moveDirection = new Vector3(horizontal, 0.0f, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // ใช้ CharacterController เพื่อเคลื่อนที่ตัวละคร
        controller.Move(moveDirection * Time.deltaTime);
    }
}
