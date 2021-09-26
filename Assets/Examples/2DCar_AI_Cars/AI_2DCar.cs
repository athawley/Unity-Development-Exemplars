using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AI_2DCar : MonoBehaviour
{
    float drift = 0.5f;
    Vector2 movement;
    Rigidbody2D rb;
    public float speed = 5;
    public float turnSpeed = 50;

    public Transform[] waypoints;
    Transform target;
    int curTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = waypoints[curTarget];
    }

    /*void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
        Debug.Log(movement.x + " - " + movement.y);
    }*/
 
    void FixedUpdate() {

        // Get Forward Velocity
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.velocity, transform.up);

        // Get Right Velocity (drift)
        Vector2 rightDrift = transform.right * Vector2.Dot(rb.velocity, transform.right);

        rb.velocity = forwardVelocity + rightDrift * drift;

        rb.AddForce(transform.up * speed * movement.y * Time.deltaTime, ForceMode2D.Force);
        rb.MoveRotation(rb.rotation + turnSpeed * -movement.x * Time.deltaTime);

        float step = speed * Time.deltaTime;

        // move sprite towards the target location

         if(transform.position == target.position) {
            // Get next target
            if(curTarget + 1 < waypoints.Length) {
               curTarget++;
               
            } else {
               curTarget = 0;
            }
            target = waypoints[curTarget];
         }

         //  Vector2 v_diff;
         //float atan2;

         transform.LookAt(target, transform.up);

         //v_diff = (target.position - transform.position);    
         //atan2 = Mathf.Atan2 ( v_diff.y, v_diff.x );
         //transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg );

        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

    }
}