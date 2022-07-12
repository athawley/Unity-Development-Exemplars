using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowerManager : MonoBehaviour
{   

    // 1. Point to spawn the enemy at from this tower
    public Transform SpawnPoint;
    // 2. Prefab of the enemy to spawn from this spawn tower
    public GameObject EnemyToSpawn;

    // 3. The object that the spawned target should aim at.
    public Transform Target;

    // 4. Ienumerator for running a coroutine to keep spawning
    private IEnumerator spawnTimer;

    // 5. The time to wait between spawning enemies from this tower.
    public float spawnDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 11. Run the spawner once
        spawnTimer = SpawnEnemy(spawnDelay);
        // 12. Start the coroutine to repeatedly
        StartCoroutine(spawnTimer);
    }

    // 6. Coroutine function to spawn enemies, will wait until time expires
    private IEnumerator SpawnEnemy(float waitTime)
    {
        // 7. Always run
        while (true)
        {
            // 8. Wait until the wait time has passed before doing anything
            yield return new WaitForSeconds(waitTime);
            // 9. Spawn / Instantiate the enemy at the location given in worldspace.
            GameObject enemyGameObject = Instantiate(EnemyToSpawn, SpawnPoint.position, Quaternion.identity);
            /* 10. 
            Set the new enemies target to the player. 
            Note that this assumes there is a script on the enemy gameobject called
            EnemyTargetPlayer with a public variable targetPosition
            */
            enemyGameObject.GetComponent<EnemyTargetPlayer>().targetPosition = Target;
        }
    }
}
