using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool GameFinished;
    [SerializeField] private GameObject losePanel;

    [SerializeField] private int maxHealth;
    private int health;
    [SerializeField]
    private TMP_Text healthText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        losePanel.SetActive(false);
        GameFinished = false;
        Time.timeScale = 1;

        health = maxHealth;

        healthText.text = "Health: " + health;
    }
    #region playerHealth
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Health: " + health;
        if(health <= 0)
        {
            GameOver();
        }
    }
        #endregion

        #region gameOver
        public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameFinished = true;
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
    #endregion
}
