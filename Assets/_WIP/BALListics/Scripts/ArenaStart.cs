using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaStart : MonoBehaviour
{
    
    public GameObject ballPrefab, gameBall;
    public List<Transform> spawnLocations = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        BALListicsGameManager.Instance.SetupGame();

        BALListicsGameManager.Instance.SpawnPlayers(spawnLocations);

        SpawnBall();
    }

    

    public void SpawnBall() {
        int spawnPointIndex = Random.Range (0, spawnLocations.Count);
        gameBall = Instantiate(ballPrefab, spawnLocations[spawnPointIndex].position, spawnLocations[spawnPointIndex].rotation);
    }
}
