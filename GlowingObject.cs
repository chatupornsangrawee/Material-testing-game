using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingObject : MonoBehaviour
{
    // ประกาศตัวแปร public สำหรับวัตถุ A หลายชิ้น
    public GameObject[] objectsA;

    // สีของการเรืองแสง
    public Color glowColor = Color.green;

    // ความเร็วในการกระพริบ (จำนวนครั้งต่อวินาที)
    public float blinkSpeed = 2.0f;

    private Material[] objectMaterials;

    void Start()
    {
        if (objectsA.Length > 0)
        {
            objectMaterials = new Material[objectsA.Length];

            for (int i = 0; i < objectsA.Length; i++)
            {
                Renderer objectRenderer = objectsA[i].GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    // ดึง Material ของ objectA
                    objectMaterials[i] = objectRenderer.material;
                    // เปิดใช้งานการเรืองแสง (Emission)
                    objectMaterials[i].EnableKeyword("_EMISSION");
                }
                else
                {
                    Debug.LogError("Renderer component missing on objectA at index " + i);
                }
            }
        }
        else
        {
            Debug.LogError("No objectsA assigned.");
        }
    }

    void Update()
    {
        if (objectMaterials != null)
        {
            float emission = Mathf.PingPong(Time.time * blinkSpeed, 0.5f);
            Color finalColor = glowColor * Mathf.LinearToGammaSpace(emission);

            for (int i = 0; i < objectMaterials.Length; i++)
            {
                if (objectMaterials[i] != null)
                {
                    objectMaterials[i].SetColor("_EmissionColor", finalColor);
                }
                else
                {
                    Debug.LogError("objectMaterials[" + i + "] is null.");
                }
            }
        }
    }
}