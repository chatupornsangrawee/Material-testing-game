using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObj : MonoBehaviour
{
    public string targetSceneName; // ชื่อของฉากที่ต้องการให้ตรวจสอบ
    public GameObject targetObject; // วัตถุที่ต้องการจะเปิดหรือปิดใช้งาน

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName && targetObject != null)
        {
            targetObject.SetActive(true); // เปิดใช้งานวัตถุ
        }
    }

    private void OnSceneUnloaded(Scene scene)
    {
        if (scene.name == targetSceneName && targetObject != null)
        {
            targetObject.SetActive(false); // ปิดการใช้งานวัตถุ
        }
    }
}