using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected GameObject panel; // this can hold both pause and settings panel
    [SerializeField] public Slider sfxSlider;
    [SerializeField] public Slider musicSlider;

  

    public void ChangeScene(int sceneNUmber)
    {
        SceneManager.LoadScene(sceneNUmber);
        Debug.Log("LOading scene number "+sceneNUmber);
    }
    public void SetSliders()
    {
        sfxSlider.value = DataSaver.Instance.GetSFXVolume(); 
        musicSlider.value = DataSaver.Instance.GetSoundVolume();
    }
    public void OpenPanel()
    {
        panel.SetActive(true);
        SetSliders();
    }
    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        MainController.Instance.UIManager.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void UpdateHealthUI(float fill)
    {

    }
    public virtual void UpdateBazookaCharge(int bazookaBullets)
    {

    }
    public virtual void UpdateScore(int score)
    {

    }
}
