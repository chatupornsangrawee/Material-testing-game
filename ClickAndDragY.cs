using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickAndDragY : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 startPosition;

    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.02f; // Adjust this value to control the intensity of the shake
    private bool isShaking = false;
    private Vector3 originalPosition;
    private float totalShakeTime = 0f;

    public string nextSceneName; // Set this in the Inspector or via script

    void Start()
    {
        originalPosition = transform.position;
    }

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
            totalShakeTime = 0f; // Reset totalShakeTime when not dragging
        }

        if (isDragging)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            newPosition.x = startPosition.x; // Maintain the object's initial X position
            newPosition.z = startPosition.z; // Maintain the object's initial Z position

            // Restrict Y position between 1.52 and 1.7
            newPosition.y = Mathf.Clamp(newPosition.y, 1.52f, 1.7f);

            // Check for continuous collision
            Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 3f);
            bool isColliding = false;

            foreach (Collider col in colliders)
            {
                if (col.CompareTag("OJ"))
                {
                    isColliding = true;
                    break;
                }
            }

            if (isColliding && !isShaking)
            {
                StartCoroutine(Shake());
            }
            else if (!isColliding && isShaking)
            {
                StopShake();
            }

            // Move the object to the new position
            transform.position = newPosition;

            // Calculate total shake time
            totalShakeTime += Time.deltaTime;

            // Check if total shake time exceeds 7 seconds
            if (totalShakeTime >= 7f)
            {
                LoadNextScene();
            }
        }
    }

    private IEnumerator Shake()
    {
        isShaking = true;
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.position = randomPoint;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        isShaking = false;
    }

    private void StopShake()
    {
        StopAllCoroutines();
        transform.position = originalPosition;
        isShaking = false;
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}