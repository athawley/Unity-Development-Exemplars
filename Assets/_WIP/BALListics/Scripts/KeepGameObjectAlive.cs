using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGameObjectAlive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static KeepGameObjectAlive Instance { get; private set; }

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
}
