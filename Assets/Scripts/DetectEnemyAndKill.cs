using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyAndKill : MonoBehaviour
{
    public static int enemyKillCount;
    public delegate void EnemyKilled(int enemyKilledCount);
    public static EnemyKilled OnEnemyKilled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            enemyKillCount++;
            OnEnemyKilled(enemyKillCount);
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
