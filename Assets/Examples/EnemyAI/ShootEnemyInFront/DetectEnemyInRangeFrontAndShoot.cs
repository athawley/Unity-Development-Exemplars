using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectEnemyInRangeFrontAndShoot : MonoBehaviour
{
    public float stopDistance = 4; // Object will stop chasing at this point
    public float chaseDistance = 8; // Object will chase from this point.

    [Range(0,360)]
    public float fieldOfViewAngle = 180;

    public string[] detectionTags; // array of tags that are to be detected

    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get all objects inside the sphere
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, chaseDistance);
        foreach (Collider hitCollider in hitColliders)
        {
            // If the object is in the same place skip it (probably itself)
            if(hitCollider.transform.position == transform.position) {
                continue;
            }

            // Check if it is an enemy object that should be attacked
            if(hitCollider.CompareTag("Enemy")) {

                // Check if target is in front of the object
                Vector3 directionToTarget = (hitCollider.transform.position - transform.position).normalized;

                Debug.Log("Angle: " + Vector3.Angle(transform.forward, directionToTarget));
                if(Vector3.Angle(transform.forward, directionToTarget) < fieldOfViewAngle / 2) {
                    Debug.Log("Seen: ");
                    // Face the object, the line below is not needed if using a navmesh agent
                    //transform.LookAt(hitCollider.transform, Vector3.up); // Face object inside the detectable area.

                    // Move to the player
                    
                    // Check if the object is in range, stop and shoot if true
                    if(Vector3.Distance(hitCollider.transform.position, transform.position) < stopDistance) {
                    
                        // Update the path and movement of the object
                        navAgent.isStopped = true;
                        navAgent.ResetPath();

                        // Take a shot when in range
                        GetComponent<CharacterActions>().Shoot();

                    } else {
                        // If not in range set the destination of the object to the target.
                        navAgent.SetDestination(hitCollider.transform.position);
                    }
                }
            }
        }
    }
}
