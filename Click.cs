using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject otherObject; // วัตถุที่ต้องการให้สั่น
    private bool isDragging = false;
    private Vector3 offset;
    private float zDistance;
    private Vector3 lastPosition;

    void OnMouseDown()
    {
        zDistance = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zDistance;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;
            targetPos.y = Mathf.Clamp(targetPos.y, 1.6f, 2.7f); // จำกัดการเคลื่อนที่ในแกน Y
            targetPos.z = Mathf.Clamp(targetPos.z, 30.5f, 32.0f); // จำกัดการเคลื่อนที่ในแกน Z
            transform.position = targetPos;

            // สร้างการสั่นสะเทือนให้กับวัตถุอื่น
            if (otherObject != null)
            {
                StartCoroutine(VibrateObject(otherObject));
            }
        }
    }

    IEnumerator VibrateObject(GameObject objToVibrate)
    {
        while (true)
        {
            // สร้างค่าสั่นในแต่ละแกน
            float xVibration = Random.Range(-0.0001f, 0.0001f);
            float yVibration = Random.Range(-0.0001f, 0.0001f);
            float zVibration = Random.Range(-0.0001f, 0.0001f);

            // ปรับตำแหน่งของวัตถุเพื่อให้สั่น
            Vector3 newPosition = objToVibrate.transform.position + new Vector3(xVibration, yVibration, zVibration);
            objToVibrate.transform.position = newPosition;

            // รอเวลาสั้นๆ ก่อนที่จะสร้างค่าสั่นใหม่
            yield return new WaitForSeconds(0.01f); // ปรับเวลาตรงนี้ตามต้องการ
        }
    }
}
