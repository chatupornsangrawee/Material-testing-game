using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectM : MonoBehaviour
{
    public GameObject objectToDisable; // วัตถุที่ต้องการปิดการใช้งาน
    public GameObject objectToEnable; // วัตถุที่ต้องการเปิดใช้งาน

    private bool isEnabled = true; // ตัวแปรสำหรับตรวจสอบว่าวัตถุถูกเปิดใช้งานอยู่หรือไม่

    private void Update()
    {
        // ตรวจสอบการกดปุ่ม Y
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (isEnabled)
            {
                StartCoroutine(EnableObjectForSeconds());
                objectToDisable.SetActive(false);
                isEnabled = false;
            }
        }
    }

    // เปิดใช้งานวัตถุเป็นเวลาหนึ่ง
    private IEnumerator EnableObjectForSeconds()
    {
        objectToEnable.SetActive(true);
        yield return new WaitForSeconds(5f); // รอเป็นเวลา 5 วินาที
        objectToEnable.SetActive(false);
        isEnabled = true;
    }
}
