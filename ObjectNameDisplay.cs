using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectNameDisplay : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToShowName;
    public float displayDistance = 3f;
    private bool isDisplayingName = false;
    private TextMesh textMesh;

    void Start()
    {
        textMesh = objectToShowName.GetComponentInChildren<TextMesh>();
        textMesh.gameObject.SetActive(false);
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, objectToShowName.transform.position);

        if (distance <= displayDistance && !isDisplayingName)
        {
            isDisplayingName = true;
            textMesh.gameObject.SetActive(true);
        }
        else if (distance > displayDistance && isDisplayingName)
        {
            isDisplayingName = false;
            textMesh.gameObject.SetActive(false);
        }
    }
}