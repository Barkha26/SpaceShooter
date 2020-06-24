using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject missilePrefab;
    public int missileGenerationCount = 10;
    int missileGenerated = 0;
    List<GameObject> missileList = new List<GameObject>();
    
    void Update ()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            missileGenerated++;
            if (missileGenerated <= missileGenerationCount)
            {
                GenerateMissile();
            }
            else if (missileList.Count > 0)
            {
                ReGenerateMissile();
            }
          
        }
		
	}

    void GenerateMissile()
    {
        GameObject obj = Instantiate(missilePrefab, transform.position, transform.rotation) as GameObject;
        obj.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f);
        missileList.Add(obj);
    }

    void ReGenerateMissile()
    {
        for (int i = 0; i < missileList.Count; i++)
        {
            if (!missileList[i].activeSelf)
            {
                missileList[i].SetActive(true);
                missileList[i].transform.position = new Vector3(transform.position.x + 1f,
                                                                transform.position.y, transform.position.z);
                missileList[i].GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f);
                return;
            }
        }
    }
}
