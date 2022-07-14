using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace PlayerLobbyExample {
public class MainMenuManager : MonoBehaviour
{
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}

}