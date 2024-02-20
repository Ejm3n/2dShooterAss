using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] protected GameObject panel; // this can hold both pause and settings panel


    protected void Awake() {
        if(Instance == null)
            Instance = this;
    }

    public void ChangeScene(int sceneNUmber)
    {
        SceneManager.LoadScene(sceneNUmber);
        Debug.Log("LOading scene number "+sceneNUmber);
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
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
        GameUIManager.Instance.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void UpdateHealthUI(float fill)
    {

    }
    public virtual void UpdateScore(int score)
    {

    }
}