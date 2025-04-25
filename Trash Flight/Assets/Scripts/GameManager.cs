using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject victoryPanel;

    private int coin = 0;

    [HideInInspector] // public이지만, 인스펙터에서는 숨김처리
    public bool isGameOver = false;

    [HideInInspector]
    public bool isWin = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; // GameManager를 넣음
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        // 코인 30개당 무기 업그레이드
        if (coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>(); // 게임 내에서 플레이어 객체를 찾음
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }

    // ===GameOver===========================
    public void SetGameOver()
    {
        isGameOver = true;

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);

    }

    //======================================

    public void SetVictory()
    {
        isWin = true;

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
        Invoke("ShowVictoryPanel", 1f);
    }
    void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
