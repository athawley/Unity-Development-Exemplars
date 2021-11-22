using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Task_2_5_Pause : MonoBehaviour
{
    bool paused = false;

    void OnPause() {
        Debug.Log("Pause Pressed");
        if(paused) {
            ResumeGame();
        } else {
            PauseGame();
        }
        paused = !paused;
    }

    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
