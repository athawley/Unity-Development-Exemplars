using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentAI : MonoBehaviour
{
    public Transform[] goals;
    NavMeshAgent agent;
    int curGoal = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.destination = new Vector3(goals[curGoal].position.x, 0.0f, goals[curGoal].position.z);
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, agent.destination);
        Debug.Log(distance);

        if(distance < agent.stoppingDistance + 2) {
            curGoal = curGoal + 1;
            if(curGoal >= goals.Length) {
                curGoal = 0;
            }
            Debug.Log(curGoal);
            agent.destination = goals[curGoal].position;
        }
    }
}
