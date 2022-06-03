using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneWithinScene : MonoBehaviour
{
    [SerializeField]
    string _sceneToLoadName;
    
    void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger Entered");
        SceneManager.LoadScene(_sceneToLoadName, LoadSceneMode.Additive);
        
    }

    
}
