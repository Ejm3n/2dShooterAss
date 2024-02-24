using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Instance;
    private int currentScore;
    private void Awake() {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }
    public void SetCurrentScore(int score)
    {
        currentScore = score;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void SetBestScore(int score)
    {
if (score > PlayerPrefs.GetInt("Best score"))
            PlayerPrefs.SetInt("Best score", score);
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("Best score");
    }
}
