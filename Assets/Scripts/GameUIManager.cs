using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUIManager : UIManager
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image healthImage, laserImage;

    protected override void Start()
    {
        UpdateBazookaCharge(0);
        base.Start();

    }
    public override void UpdateHealthUI(float fill)
    {
        healthImage.fillAmount = fill;

    }
    public override void UpdateScore(int score)
    {
        scoreText.text = "Score: " +score.ToString();
    }
    public override void UpdateBazookaCharge(int bazookaBullets)
    {
        laserImage.fillAmount = (float)bazookaBullets/5f; // sorry about this 5f we need to not forget
    }
}
