using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdateAndShowResult : MonoBehaviour
{
    [SerializeField] Text alienKillCount;
    [SerializeField] Text remainingEnemy;
    string temp_alienKillCount;
    string temp_remainingEnemy;
    [SerializeField] GameObject gameplay;
    [SerializeField] Canvas resultCanvas;
    Canvas tempCanvas;
    [SerializeField] Text resultText;
    [SerializeField] private int NeedToEnemyToWin;
    int temp_NeedToEnemyToWin;
    // Use this for initialization
    private void OnEnable()
    {
        DetectEnemyAndKill.OnEnemyKilled += UpdateScore;
        GetThePlayerAndKill.OnPlayerKilled += YouLoose;
    }
    void Start ()
    {
        tempCanvas = resultCanvas.GetComponent<Canvas>();
        temp_alienKillCount = alienKillCount.text;
        alienKillCount.text = temp_alienKillCount + ""+0;
        temp_remainingEnemy = remainingEnemy.text;
        temp_NeedToEnemyToWin = NeedToEnemyToWin;
        remainingEnemy.text = temp_remainingEnemy + NeedToEnemyToWin.ToString();
    }
	
    void UpdateScore(int enemyKillCount)
    {
        temp_NeedToEnemyToWin--;
        remainingEnemy.text = temp_remainingEnemy + temp_NeedToEnemyToWin.ToString();
        alienKillCount.text = temp_alienKillCount + enemyKillCount.ToString();
        if (enemyKillCount == NeedToEnemyToWin)
        {
            gameplay.SetActive(false);
            tempCanvas.enabled = true;
            resultText.text = "You Win";
        }
    }

    void YouLoose()
    {
        gameplay.SetActive(false);
        tempCanvas.enabled = true;
        resultText.text = "You Loose";
    }

    private void OnDisable()
    {
        DetectEnemyAndKill.OnEnemyKilled -= UpdateScore;
        GetThePlayerAndKill.OnPlayerKilled -= YouLoose;
    }
}
