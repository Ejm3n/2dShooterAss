using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndUiManager : UIManager
{
    [SerializeField] private TMP_Text currentScoreText;
    [SerializeField] private TMP_Text bestScoreText;

    protected override void Start() {
        SetCurrentScore();
        SetBestScore();
    }
    private void SetCurrentScore()
    {
currentScoreText.text = "Your score: " + MainController.Instance.DataSaver.GetCurrentScore().ToString();
    }
    private void SetBestScore()
    {
        bestScoreText.text = "Best score: " + MainController.Instance.DataSaver.GetBestScore().ToString();
    }
}
