using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovemnet : MonoBehaviour
{

    Camera cam;
    Vector3 startPos;
    private void Awake()
    {
        cam = Camera.main;
        startPos = transform.position;

    }
    private void OnEnable()
    {
        transform.position = startPos;
    }
    void Update()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width || screenPosition.x < 0 ||
            screenPosition.y > Screen.width || screenPosition.y < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
