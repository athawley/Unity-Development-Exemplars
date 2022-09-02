using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTeam : MonoBehaviour
{
    public string team;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            col.GetComponent<BALListicsPlayerManager>().ChangeTeam(team);
        }

        BALListicsGameManager.Instance.CheckReady();
    }

    void OnTriggerExit(Collider col) {
        if(col.CompareTag("Player")) {
            col.GetComponent<BALListicsPlayerManager>().ChangeTeam("None");
        }
    }
}
