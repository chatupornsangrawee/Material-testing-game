using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // เพิ่มส่วนนี้เพื่อให้สามารถเรียกใช้ UnlockMouse จาก PlayerCon ได้
    public static void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        // เรียกใช้ UnlockMouse() เมื่อเริ่มเล่นเกมหรือเริ่มด่านใหม่
        UnlockMouse();
    }
}