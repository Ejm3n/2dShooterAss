using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void SetScore(string score)
    {
        PlayerPrefs.SetString("Score", score);
    }
    public void GetScore()
    {
        PlayerPrefs.GetString("Score");
    }
}
