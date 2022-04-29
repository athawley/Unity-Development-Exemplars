using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMovementNavMeshController : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnMove(InputValue iv) {
        Vector2 temp = iv.Get<Vector2>();
        movement = new Vector3(temp.x, 0.0f, temp.y);
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");
 
        //movement.Set(horizontalInput, 0f, verticalInput);
 
        agent.Move(movement * Time.deltaTime * agent.speed);
        agent.SetDestination(transform.position + movement);
    
    }
}
