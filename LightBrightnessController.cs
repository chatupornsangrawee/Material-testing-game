using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBrightnessController : MonoBehaviour
{
    public List<Light> pointLights; // List ของ Point Light ที่จะปรับความสว่าง
    public Slider brightnessSlider; // Slider ที่ใช้ในการปรับความสว่าง
    public Text lightIntensityText; // กล่องข้อความ UI ที่ใช้แสดงค่าความสว่าง
    public GameObject objectToDestroy; // วัตถุที่จะทำลายเมื่อค่าความสว่างต่ำกว่า 20 lux

    void Start()
    {
        // ตั้งค่า Slider ให้ตรงกับค่าความสว่างเริ่มต้นของ Point Light แรกใน List
        brightnessSlider.value = pointLights[0].intensity;
        // เชื่อมตัวฟังก์ชัน AdjustBrightness เข้ากับเหตุการณ์ OnValueChanged ของ Slider
        brightnessSlider.onValueChanged.AddListener(AdjustBrightness);
        // ตรวจสอบค่าความสว่างเมื่อเริ่มเล่นเกม
        UpdateLightIntensityText(pointLights[0].intensity);
    }

    public void AdjustBrightness(float value)
    {
        // เมื่อปรับค่า Slider ให้เรียกใช้เมทอดนี้เพื่อปรับค่าความสว่างของทุก Point Light ใน List
        foreach (Light light in pointLights)
        {
            light.intensity = value;
        }
        // อัปเดตค่าความสว่างที่แสดงในกล่องข้อความ UI
        UpdateLightIntensityText(value);

        // ตรวจสอบและทำลายวัตถุเมื่อค่าความสว่างต่ำกว่า 20 lux
        if (value < 0.215f) // 20 lux เมื่อแปลงเป็นค่า intensity ใน Unity
        {
            Destroy(objectToDestroy);
        }
    }

    void UpdateLightIntensityText(float intensityValue)
    {
        // คำนวณค่าความสว่างในหน่วย lux (ตัวอย่างเท่านั้น อาจต้องปรับแก้ให้ตรงกับโครงการของคุณ)
        float luxValue = intensityValue * 100; // ปรับค่า intensity เป็น lux (ในที่นี้เราสมมติว่า 1 intensity = 1 lux)

        // กำหนดข้อความที่จะแสดงในกล่องข้อความ UI
        lightIntensityText.text = "Light Intensity: " + luxValue.ToString("F2") + " lux"; // แสดงค่า lux ที่มีทศนิยม 2 ตำแหน่ง
    }
}