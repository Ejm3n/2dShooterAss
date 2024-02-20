using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndUiManager : UIManager
{
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text bestScoreText;

    private void Start() {
        SetCurrentScore();
        SetBestScore();
    }
    private void SetCurrentScore()
    {
currentScoreText.text = "Your score: " + DataSaver.Instance.GetCurrentScore().ToString();
    }
    private void SetBestScore()
    {
        bestScoreText.text = "Best score: " + DataSaver.Instance.GetBestScore().ToString();
    }
}
