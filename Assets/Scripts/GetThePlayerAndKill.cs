using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetThePlayerAndKill : MonoBehaviour
{
    public delegate void PlayerKilled();
    public static PlayerKilled OnPlayerKilled;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnPlayerKilled();
            collision.gameObject.SetActive(false);
        }
    }
}
