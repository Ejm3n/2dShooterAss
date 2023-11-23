using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool GameFinished;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        losePanel.SetActive(false);
        GameFinished = false;
        Time.timeScale = 1;
    }

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
}
