using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWithinScene : MonoBehaviour
{
    [SerializeField]
    string _sceneToLoadName;
    [SerializeField]
    string _sceneTounloadName;
    
    void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger Entered");
        if(_sceneToLoadName != "") {
            SceneManager.LoadScene(_sceneToLoadName, LoadSceneMode.Additive);
        }
        if(_sceneTounloadName != "") {
            SceneManager.UnloadSceneAsync(_sceneTounloadName);
        }
        
    }

    
}
