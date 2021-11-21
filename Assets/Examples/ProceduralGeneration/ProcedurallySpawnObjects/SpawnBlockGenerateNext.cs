using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlockGenerateNext : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") == true) {
            // Collided with the player
            //GameManager.Instantiate()
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().CreateNextSpawnBlock();
        }
    }
}
