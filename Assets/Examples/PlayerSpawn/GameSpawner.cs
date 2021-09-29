using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSpawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(enemy, new Vector3(0,2,1), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
