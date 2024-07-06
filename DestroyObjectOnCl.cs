using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObjectOnCl : MonoBehaviour
{
    // ตัวแปร Public ที่จะเก็บวัตถุที่จะทำลาย
    public GameObject objectToDestroy;

    // ฟังก์ชันนี้จะถูกเรียกเมื่อกดปุ่ม
    public void DestroyObject()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }
}