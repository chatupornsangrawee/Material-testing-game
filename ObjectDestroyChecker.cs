using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectDestroyChecker : MonoBehaviour
{
    public GameObject[] objectsToCheck;
    public string nextSceneName;
    public float waitTime = 3f; // เวลาที่ต้องการรอ (วินาที)

    void Update()
    {
        if (CheckAllObjectsDestroyed())
        {
            StartCoroutine(WaitAndLoadNextScene());
        }
    }

    bool CheckAllObjectsDestroyed()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            if (obj != null)
            {
                return false; // มี GameObject ที่ยังไม่ถูกทำลาย
            }
        }
        return true; // ทุก GameObject ถูกทำลายแล้ว
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(waitTime); // รอเวลาที่กำหนด

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not specified.");
        }
    }
}