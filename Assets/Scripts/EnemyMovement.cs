using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speedOfEnemy = 2f;
    Vector3 startPos;
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
        startPos = transform.position;
        
    }

    private void OnEnable()
    {
        startPos = new Vector3(startPos.x, Random.Range(5, -5), startPos.z);
        transform.position = startPos;
    }
    void Update ()
    {
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);
        if (screenPosition.x > Screen.width || screenPosition.x < 0 ||
            screenPosition.y > Screen.width || screenPosition.y < 0)
        {
            
            transform.position = startPos;
            
        }
        else
        {
            transform.position = new Vector3(transform.position.x - (speedOfEnemy * Time.deltaTime),
                                             transform.position.y, transform.position.z
                                            );
        }
           
    }

}
