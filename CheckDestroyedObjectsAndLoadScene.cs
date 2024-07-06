using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckDestroyedObjectsAndLoadScene : MonoBehaviour
{
    public List<GameObject> objectsToCheck; // ลิสต์ public สำหรับเก็บอ้างอิงวัตถุที่ต้องการตรวจสอบ
    public string sceneToLoad; // ตัวแปร public สำหรับเก็บชื่อฉากที่ต้องการโหลด

    void Update()
    {
        bool allDestroyed = true;

        foreach (GameObject obj in objectsToCheck)
        {
            if (obj != null)
            {
                allDestroyed = false;
                break;
            }
        }

        if (allDestroyed)
        {
            LoadScene(sceneToLoad); // เรียกฟังก์ชันโหลดฉาก
        }
    }

    void LoadScene(string sceneName)
    {
        Debug.Log("All objects have been destroyed. Loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}