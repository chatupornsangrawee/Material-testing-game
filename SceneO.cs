using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneO : MonoBehaviour
{
    public string targetSceneName; // ชื่อของฉากที่ต้องการให้ตรวจสอบ
    public GameObject targetObject; // วัตถุที่ต้องการจะเปิดใช้งาน

    private bool isActive; // เก็บสถานะการเปิด/ปิดใช้งานของวัตถุ

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;

        // เริ่มต้นตั้งค่าเป็นปิดใช้งาน
        isActive = false;
        if (targetObject != null)
        {
            targetObject.SetActive(isActive);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            // เปิดใช้งานวัตถุเมื่ออยู่ในฉากที่ต้องการ
            isActive = true;
            if (targetObject != null)
            {
                targetObject.SetActive(isActive);
            }
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {
        if (scene.name == targetSceneName)
        {
            // ไม่ต้องปิดใช้งานเมื่อฉากถูกปล่อยออกไป
            // สามารถเปิดใช้งานอีกครั้งเมื่อกลับเข้าฉากนี้
        }
    }
}