using UnityEngine;

public class DestroyObjectOnKeyPr : MonoBehaviour
{
    public GameObject objectToDestroy;

    void Update()
    {
        // ตรวจสอบการกดปุ่ม C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // ทำลายวัตถุที่กำหนด
            if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
            }
            else
            {
                Debug.LogWarning("ไม่ได้กำหนดวัตถุที่ต้องการทำลายในตัวแปร public");
            }
        }
    }
}
