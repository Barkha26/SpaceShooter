using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawing : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyPos;
    GameObject obj;
    public int enemyCount = 10;
    int enemyGenerated;
    List<GameObject> enemyList = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating("generateEnemy", 0, 0.5f);
    }
   
    void generateEnemy()
    {
        
        enemyGenerated++;
        if(enemyGenerated <= enemyCount)
        {
            GenerateEnemy();
        }
        else if (enemyGenerated > enemyCount)
        {
            ReGenerateEnemy();
        }
       
    }
    void GenerateEnemy()
    {
        Vector3 pos = new Vector3(enemyPos.position.x, Random.Range(5, -5), enemyPos.position.z);
        obj = Instantiate(enemyPrefab, pos, enemyPos.rotation) as GameObject;
        enemyList.Add(obj);
    }

    void ReGenerateEnemy()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeSelf)
            {
                enemyList[i].SetActive(true);
            }

        }
    }
}
