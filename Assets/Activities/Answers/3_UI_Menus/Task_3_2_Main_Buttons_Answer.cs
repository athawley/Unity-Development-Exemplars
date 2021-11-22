using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Task_3_2_Main_Buttons_Answer : MonoBehaviour
{
    public string playScene;
    public string aboutScene;
    public void LoadScene(string s) {
        SceneManager.LoadScene(s);
    }

    public void Quit() {
        Application.Quit();
    }
}
