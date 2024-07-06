using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1Controller : MonoBehaviour
{
    public GameObject A1;
    public GameObject A2;

    void Update()
    {
        // ตรวจสอบว่า A1 มีการทำงานอยู่หรือไม่
        if (A1 != null && A1.activeSelf)
        {
            // ถ้า A1 ทำงานอยู่ ก็ให้ A2 ทำงาน
            if (A2 != null)
            {
                A2.SetActive(true); // สั่งให้ A2 ทำงาน
            }
        }
    }
}