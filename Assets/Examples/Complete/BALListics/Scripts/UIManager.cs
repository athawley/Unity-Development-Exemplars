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
        DontDestroyOnLoad(this.gameObject);
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
    public Canvas mainMenu, pauseMenu, aboutMenu, resultMenu;

    public EventSystem eventSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        ChangeGameLength();
    }

    public void LoadScene(string scene) {
        SceneManager.LoadSceneAsync(scene);
    }

    public void PauseGame() {
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

    public void DisplayResult(string result, string score) {
        resultMenu.GetComponent<ResultUpdate>().result.text = result;
        resultMenu.GetComponent<ResultUpdate>().score.text = score;
        resultMenu.gameObject.SetActive(true);
    }

    public void MainMenu() {
        /*
        aboutMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(active.gameObject);*/
        pauseMenu.gameObject.SetActive(false);
        aboutMenu.gameObject.SetActive(false);
        resultMenu.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
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
