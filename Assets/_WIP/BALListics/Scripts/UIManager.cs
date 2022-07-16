using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public bool gamePaused = false;

    public int gameLength = 30;

    public Slider gameLengthSlider;
    public Text gamLengthText;

    // Canvases
    public Canvas mainMenu, pauseMenu, aboutMenu;

    public EventSystem eventSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        ChangeGameLength();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene) {
        SceneManager.LoadSceneAsync(scene);
    }

    public void PauseGame(Button active) {
        pauseMenu.gameObject.SetActive(true);
        Debug.Log("Pause pressed");
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void AboutMenu(Button active) {
        aboutMenu.gameObject.SetActive(true);
        
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(active.gameObject);
        mainMenu.gameObject.SetActive(false);
    }

    public void MainMenu(Button active) {
        aboutMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(active.gameObject);
    }

    public void ChangeGameLength() {
        gameLength = (int)gameLengthSlider.value * 30;
        int minutes = gameLength / 60;
        int seconds = gameLength % 60;
        string tmp = "Game Length:" + minutes + ":";
        if(seconds < 10) {
            tmp = tmp + "0" + seconds;
        } else {
            tmp = tmp + seconds;
        }
        gamLengthText.text = tmp;
        //BALListicsGameManager.Instance.matchLengthSeconds = gameLength;
    }

    public void Quit() {
        Application.Quit();
    }

    public void ResumeGame() {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
}
