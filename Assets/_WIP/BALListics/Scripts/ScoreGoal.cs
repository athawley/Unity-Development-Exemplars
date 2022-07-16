using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    [SerializeField]
    string team;
    
    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Ball")) {
            col.gameObject.transform.position = Vector3.zero;
            BALListicsGameManager.Instance.scoreTeam(team);
        }
    }
}
