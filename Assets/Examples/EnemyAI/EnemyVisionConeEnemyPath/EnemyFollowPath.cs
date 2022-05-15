using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPath : MonoBehaviour
{

    [SerializeField]
    GameObject _wayPointsContainer;
    Transform[] _wayPoints;

    int _targetWayPoint = 1;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _wayPoints = _wayPointsContainer.transform.GetComponentsInChildren<Transform>();
        //_navMeshAgent.SetDestination(_wayPoints[_targetWayPoint].position);
        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.5f)
                GotoNextPoint();
    }

/*    void OnTriggerEnter(Collider col) {
        Debug.Log("Enemy Collided with location");
        if(col.CompareTag("WayPoint")) {
            Debug.Log("Enemy Collided with WayPoint");
            // Get next waypoint
            _targetWayPoint = _targetWayPoint + 1;
            if(_targetWayPoint >= _wayPoints.Length) {
                _targetWayPoint = 1;
            }
            _navMeshAgent.SetDestination(_wayPoints[_targetWayPoint].position);
        }
    }*/

    void GotoNextPoint() {
            // Returns if no points have been set up
            if (_wayPoints.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            _navMeshAgent.destination = _wayPoints[_targetWayPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            _targetWayPoint = (_targetWayPoint + 1) % _wayPoints.Length;
            if(_targetWayPoint == 0) {
                _targetWayPoint = 1;
            }
        }
}
