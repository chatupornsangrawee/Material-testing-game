using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // ตัวแปรสำหรับเก็บชื่อฉากที่ต้องการโหลด

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); // โหลดฉากตามชื่อที่กำหนด
    }
}