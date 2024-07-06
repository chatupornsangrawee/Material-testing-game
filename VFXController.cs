using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class VFXController : MonoBehaviour
{
    public GameObject vfxObject; // เลือก GameObject ที่มี Component VFX จาก Inspector
    private ParticleSystem vfx; // เก็บ Component ของ VFX
    public string nextSceneName; // ชื่อฉากต่อไปที่ต้องการโหลด

    void Start()
    {
        // ตรวจสอบว่า GameObject มี Component VFX หรือไม่
        vfx = vfxObject.GetComponent<ParticleSystem>();
        if (vfx == null)
        {
            Debug.LogError("No VFX component found on the specified GameObject.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // เมื่อคลิกเม้าส์
        {
            StartCoroutine(StartVFXAndCheckTimer()); // เริ่มเล่น VFX และตรวจสอบเวลา
        }
    }

    IEnumerator StartVFXAndCheckTimer()
    {
        // เริ่มเล่น VFX
        StartVFX();

        // เริ่มตั้งเวลาในการตรวจสอบ
        float timer = 0f;
        while (timer < 5f) // ตรวจสอบเวลาเกิน 10 วินาทีหรือไม่
        {
            timer += Time.deltaTime;
            yield return null;
        }

        // ถ้าเวลาเกิน 10 วินาที ให้โหลดฉากต่อไป
        LoadNextScene();
    }

    void StartVFX()
    {
        if (vfx != null)
        {
            vfx.Play(); // เริ่มเล่น VFX
        }
    }

    void LoadNextScene()
    {
        // โหลดฉากต่อไปที่กำหนด
        SceneManager.LoadScene(nextSceneName);
    }
}
