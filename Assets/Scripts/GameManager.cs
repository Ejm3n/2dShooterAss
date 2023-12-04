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


    [SerializeField]private TMP_Text healthText;
    
    private PlayerHealth playerHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        losePanel.SetActive(false);
        GameFinished = false;
        Time.timeScale = 1;

        
        playerHealth = FindObjectOfType<PlayerHealth>();
       
    }
    private void Start()
    {
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {

        healthText.text = "Health: " + playerHealth.CurrentHealth;

    }
     

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
