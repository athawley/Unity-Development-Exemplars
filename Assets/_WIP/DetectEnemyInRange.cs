using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectEnemyInRange : MonoBehaviour
{
    public float stopDistance = 4; // Object will stop chasing at this point
    public float chaseDistance = 8; // Object will chase from this point.

    public string[] detectionTags; // array of tags that are to be detected

    private NavMeshAgent navAgent; // Nav mesh agent for AI pathfinding, needs a navmesh created

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find all the objects / colliders inside a set distance in any direction (sphere)
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, chaseDistance);

        // Go through each object that is inside the sphere checked earlier.
        foreach (Collider hitCollider in hitColliders)
        {
            // If the object is at the same location as this one skip it.
            if(hitCollider.transform.position == transform.position) {
                continue;
            }
            //hitCollider.SendMessage("In Range");

            if(hitCollider.CompareTag("Enemy")) {
                //Debug.Log("In range: " + hitCollider.gameObject.ToString());
                transform.LookAt(hitCollider.transform, Vector3.up); // Face object inside the detectable area.

                // Move to the player
                
                //Debug.Log(Vector3.Distance(hitCollider.transform.position, transform.position));
                if(Vector3.Distance(hitCollider.transform.position, transform.position) < stopDistance) {
                   // If inside the set distance stop the object and reset the navigation path.
                   navAgent.isStopped = true;
                   navAgent.ResetPath();
                } else {
                    // Set the destination to the object the collision was detected with
                    navAgent.SetDestination(hitCollider.transform.position); 
                }
            }
        }
    }
}
