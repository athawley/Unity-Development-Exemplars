using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowerManager : MonoBehaviour
{   
    
    public Transform SpawnPoint;
    public GameObject EnemyToSpawn;

    private IEnumerator spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnTimer = SpawnEnemy(2.0f);
        StartCoroutine(spawnTimer);
    }

    private IEnumerator SpawnEnemy(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(EnemyToSpawn, SpawnPoint.position, Quaternion.identity);
        }
    }
}
