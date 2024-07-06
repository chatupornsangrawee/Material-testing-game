using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider uWcm2Slider; // Slider ปรับค่า uW/cm2
    public Slider temperatureSlider; // Slider ปรับค่าอุณหภูมิ
    public Text uWcm2ValueText; // Text แสดงค่า uW/cm2
    public Text temperatureValueText; // Text แสดงค่าอุณหภูมิ

    public List<GameObject> objectsToDestroy; // วัตถุที่จะทำลาย

    void Start()
    {
        // ตั้งค่า Slider ให้ตรงกับค่าเริ่มต้นที่ต้องการ
        uWcm2Slider.value = 500; // ค่าเริ่มต้น uW/cm2
        temperatureSlider.value = 100; // ค่าเริ่มต้นอุณหภูมิ

        UpdateValues(); // อัพเดตค่าเริ่มต้น
    }

    public void OnuWcm2SliderChanged()
    {
        UpdateValues();
    }

    public void OnTemperatureSliderChanged()
    {
        UpdateValues();
    }

    void UpdateValues()
    {
        // จำกัดค่าของ Slider ให้อยู่ในช่วงที่กำหนด
        float uWcm2Value = Mathf.Clamp(uWcm2Slider.value, 0f, 10000f);
        float temperatureValue = Mathf.Clamp(temperatureSlider.value, 0f, 100f);

        // อัปเดตค่า Text แสดงผล
        uWcm2ValueText.text = "" + uWcm2Value.ToString("F0") + "uW/cm2";
        temperatureValueText.text = "" + temperatureValue.ToString("F0") + "°C";

        // เช็คเงื่อนไขเมื่อ uWcm2Slider > 1000 และ temperatureSlider <= 71
        if (uWcm2Slider.value > 1000 && temperatureSlider.value <= 71)
        {
            // วนลูปทุกวัตถุที่ต้องการทำลาย
            foreach (GameObject obj in objectsToDestroy)
            {
                // ทำการทำลายวัตถุที่กำหนด
                Destroy(obj);
            }
        }
    }
}