using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Task_3_3_Pause : MonoBehaviour
{
    bool paused = false;
    PlayerInput playerInput;
    [SerializeField] Canvas pauseMenu;

    void Start() {
        playerInput = GetComponent<PlayerInput>();
    }

    void OnFire() {
        Debug.Log("Fire, pew pew, boom, boom, I got you!");
    }

    void OnPause() {
        Debug.Log("Pause Pressed");
        PauseGame();
    }

    void PauseGame ()
    {
        playerInput.actions.Disable();
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        playerInput.actions.Enable();
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
