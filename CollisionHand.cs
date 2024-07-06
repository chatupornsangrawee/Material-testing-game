using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHand : MonoBehaviour
{
    public string targetTag = "YourTag"; // กำหนด Tag ของวัตถุที่จะตรวจสอบ
    public GameObject objectToCheck; // กำหนดวัตถุที่ต้องการเช็คว่าถูกทำลายหรือไม่
    public string nextSceneName = "NextScene"; // กำหนดชื่อฉากที่ต้องการโหลดต่อไป

    private void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าวัตถุที่ชนมี Tag ที่กำหนดหรือไม่
        if (collision.gameObject.CompareTag(targetTag))
        {
            // ตรวจสอบว่าวัตถุที่ต้องการเช็คถูกทำลายหรือไม่
            if (IsObjectDestroyed())
            {
                // โหลดฉากต่อไปที่กำหนด
                LoadNextScene();
            }
        }
    }

    // ฟังก์ชันตรวจสอบว่าวัตถุถูกทำลายหรือไม่
    private bool IsObjectDestroyed()
    {
        if (objectToCheck == null)
        {
            // ถ้าวัตถุถูกทำลายแล้วหรือไม่มี
            return true;
        }
        else
        {
            // ตรวจสอบว่าวัตถุยังอยู่ในฉากหรือไม่
            return !objectToCheck.activeInHierarchy;
        }
    }

    // ฟังก์ชันโหลดฉากต่อไป
    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName); // โหลดฉากต่อไปตามชื่อที่กำหนด
    }
}