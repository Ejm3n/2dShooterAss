using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool GameFinished;

    [SerializeField] private float distanceToPlayerToActivateSounds = 7f;
    

    private PlayerHealth playerHealth;
    private Transform playerTransform;
    private int score=0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        //losePanel.SetActive(false);
        GameFinished = false;
        GameUIManager.Instance.SetTimeScale(1);

        score = 0;
        AddScore(0);
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerTransform = playerHealth.transform;
    }
    private void Start()
    {
       GameUIManager.Instance.UpdateHealthUI(1);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameUIManager.Instance.SetTimeScale(0f);
            GameUIManager.Instance.OpenPanel();
        }
    }
        #region gameOver    
    public void GameOver()
    {
        GameFinished = true;
       // scoreEndText.text = "Your score: " + score.ToString();
        DataSaver.Instance.SetCurrentScore(score);
        DataSaver.Instance.SetBestScore(score);
       // bestScoreText.text = "Best score: " + DataSaver.Instance.GetBestScore().ToString();
        Time.timeScale = 0;
        //losePanel.SetActive(true);
        GameUIManager.Instance.ChangeScene(2);
    }
    public float GetMaxDistanceToPlayer()
    {
        return distanceToPlayerToActivateSounds;
    }
    public Vector2 GetPlayerPos()
    {
        return playerTransform.position;
    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        GameUIManager.Instance.UpdateScore(score);
    }

    #endregion
}
