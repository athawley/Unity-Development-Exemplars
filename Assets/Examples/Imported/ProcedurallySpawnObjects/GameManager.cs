using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject spawnBlockTemplate;

    int spawnCount = 0;
    int spawnBlockOffset = 15;
    
    Queue<GameObject> spawnBlocks = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //spawnBlockOffset = spawnBlockTemplate.GetComponent<Plane>().GetLength(3);
        CreateNextSpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNextSpawnBlock() {
        spawnCount++;
        GameObject sb = Instantiate(spawnBlockTemplate, new Vector3(0.0f, 0.0f, spawnBlockOffset * spawnCount), Quaternion.identity);
        spawnBlocks.Enqueue(sb);

        Debug.Log(spawnBlocks.Count);

        if(spawnBlocks.Count > 2) {
            //GameObject removeGO = spawnBlocks.Dequeue();
            Destroy(spawnBlocks.Dequeue());
        }
    }
}
