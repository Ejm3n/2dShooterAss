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
    

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image healthImage;

    [Header("ENDGAME STUFF")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMP_Text scoreEndText;
    [SerializeField] protected TMP_Text bestScoreText;

    private PlayerHealth playerHealth;
    private int score=0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        losePanel.SetActive(false);
        GameFinished = false;
        Time.timeScale = 1;

        score = 0;
        AddScore(0);
        playerHealth = FindObjectOfType<PlayerHealth>();
       
    }
    private void Start()
    {
        UpdateHealthUI(1);
    }
    public void UpdateHealthUI(float fill)
    {
        healthImage.fillAmount = fill;

    }
     

        #region gameOver
        public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameFinished = true;
        scoreEndText.text = "Your score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("Best score"))
            PlayerPrefs.SetInt("Best score", score);
        bestScoreText.text = "Best score: " + PlayerPrefs.GetInt("Best score").ToString();
        Time.timeScale = 0;
        losePanel.SetActive(true);

    }
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    #endregion
}
