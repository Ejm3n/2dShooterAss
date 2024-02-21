using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIManager : UIManager
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image healthImage, laserImage;

    public override void UpdateHealthUI(float fill)
    {
        healthImage.fillAmount = fill;

    }
    public override void UpdateScore(int score)
    {
        scoreText.text = "Score: " +score.ToString();
    }
    public override void UpdateLaserCharge(float charge)
    {
        laserImage.fillAmount = charge;
    }
}
