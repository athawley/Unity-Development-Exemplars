using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyChase
{
    

public class EnemyChasePlayer : MonoBehaviour
{
    [SerializeField]
    GameObject _visionObject;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_visionObject.GetComponent<EnemyVisionDetection>().trackingPlayer) {
            // Player detected.

            //Debug.Log("Tracking");
            _navMeshAgent.destination = _visionObject.GetComponent<EnemyVisionDetection>().playerPosition;
            //_visionObject.GetComponent<EnemyVisionDetection>().trackingPlayer = false;
        } 
    }
}

}
