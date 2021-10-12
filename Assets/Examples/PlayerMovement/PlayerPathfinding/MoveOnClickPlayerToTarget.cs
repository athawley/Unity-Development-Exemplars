using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOnClickPlayerToTarget : MonoBehaviour
{
    public GameObject target;
    public int speed = 5;

    private NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the target but do not include the targets y axis as this would rotate the player, use the player y axis to maintain verticality
        Vector3 targetPosition = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
        // Transform the player to look at the target.
        transform.LookAt(targetPosition);
        // move the player towards the target,
        navAgent.SetDestination(target.transform.position);
    }
}
