using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_3_4_Answer_LavaRespawner : MonoBehaviour
{
    [SerializeField] Transform spawnLocation;
    [SerializeField] GameObject gm;
    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            Debug.Log("You Died");
            gm.GetComponent<Task_3_4_Answer_Timer>().LoseLife();
            col.gameObject.SetActive(false);
            col.gameObject.transform.position = spawnLocation.position;
            col.gameObject.SetActive(true);
        }
    }
}
