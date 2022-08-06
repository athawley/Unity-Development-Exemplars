using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGoal : MonoBehaviour
{
    [SerializeField]
    string pointsToTeam;

    public GameObject game;
    
    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Ball")) {
            Destroy(col.gameObject);
            game.GetComponent<ArenaStart>().SpawnBall();
            BALListicsGameManager.Instance.scoreTeam(pointsToTeam);
        }
    }
}
