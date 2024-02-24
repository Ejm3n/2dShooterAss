using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static MainController Instance;

   
    public SoundManager SoundManager;

    public UIManager UIManager;
    [SerializeField] private UIManager MainMenuUIManager;
    [SerializeField] private UIManager MainGameUIManager;
    [SerializeField] private UIManager EndSceneUIManager;

    public DataSaver DataSaver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }          
        else
            Destroy(gameObject);
     
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            MainMenuUIManager.gameObject.SetActive(true);
            UIManager = MainMenuUIManager;
            MainGameUIManager.gameObject.SetActive(false);
            EndSceneUIManager.gameObject.SetActive(false);
        }
            
        else if(scene.buildIndex == 1)
        {
            MainGameUIManager.gameObject.SetActive(true);
            UIManager = MainGameUIManager;
            MainMenuUIManager.gameObject.SetActive(false);
           EndSceneUIManager.gameObject.SetActive(false);
        }
           
        else if(scene.buildIndex == 2)
        {
            EndSceneUIManager.gameObject.SetActive(true);
            UIManager = EndSceneUIManager;
            MainMenuUIManager.gameObject.SetActive(false);
            MainGameUIManager.gameObject.SetActive(false);
            
        }
        UIManager.SetSliders();
    }
}
