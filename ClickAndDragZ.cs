using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDragZ : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    startPosition = transform.position;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            newPosition.x = startPosition.x; // Maintain the object's initial X position
            newPosition.y = startPosition.y; // Maintain the object's initial Y position
            transform.position = newPosition;
        }
    }
}
