using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. Use the AI package to manage AI pathfinding on navmeshs
using UnityEngine.AI;

public class EnemyTargetPlayer : MonoBehaviour
{
    // 2. The target for the object to move towards
    public Transform targetPosition;
    // 3. The navmesh agent
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        // 4. Get the navmesh agent attached to this gameobject
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 5. Every frame update the targetPosition of the agent (in case it moves)
        agent.SetDestination(targetPosition.position);
    }   
}