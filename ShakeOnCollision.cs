using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnCollision : MonoBehaviour
{
public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.02f; // ปรับค่านี้ลงเพื่อลดความแรงของการสั่น
    public string collisionTag = "OJ";

    private bool isShaking = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        // Check for continuous collision
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 3f);
        bool isColliding = false;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag(collisionTag))
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
    }

    private IEnumerator Shake()
    {
        isShaking = true;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            float shakeAmountX = Random.Range(-shakeMagnitude, shakeMagnitude);
            float shakeAmountY = Random.Range(-shakeMagnitude, shakeMagnitude);
            float shakeAmountZ = Random.Range(-shakeMagnitude, shakeMagnitude);

            // Clamp each shake amount to not exceed 0.01
            shakeAmountX = Mathf.Clamp(shakeAmountX, -0.01f, 0.01f);
            shakeAmountY = Mathf.Clamp(shakeAmountY, -0.01f, 0.01f);
            shakeAmountZ = Mathf.Clamp(shakeAmountZ, -0.01f, 0.01f);

            Vector3 randomPoint = originalPosition + new Vector3(shakeAmountX, shakeAmountY, shakeAmountZ);
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
}
