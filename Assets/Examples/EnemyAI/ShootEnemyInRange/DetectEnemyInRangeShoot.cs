using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectEnemyInRangeShoot : MonoBehaviour
{
    public float stopDistance = 4; // Object will stop chasing at this point
    public float chaseDistance = 8; // Object will chase from this point.

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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, chaseDistance);
        foreach (Collider hitCollider in hitColliders)
        {
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
                   
                    navAgent.isStopped = true;
                    navAgent.ResetPath();

                    // Take a shot when in range
                    GetComponent<CharacterActions>().Shoot();

                } else {
                    navAgent.SetDestination(hitCollider.transform.position);
                }
            }
        }
    }
}
