using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class PlayerMovementFPS_MLAPI : NetworkBehaviour
{
    // x for l/r, y for f/b
    public Vector2 moveInputVector;
    // x for rotate l/r, y for look u/d
    public Vector2 lookInputVector;

    public Transform lookTransformPoint;

    // Movement and Look Variables
    public float moveSpeed = 25;
    public float turnSpeed = 200;

    public float lookRotateDirection = 0;
    public float maxVerticalLookAngle = 80;
    public float lookVerticalDirection = 0;

    public float velocity = 0;
    public float gravity = 9.8f;

    public GameObject[] spawnLocations;

    public CharacterController characterController;

   private PlayerControlsMLAPI controls;

    private PlayerControlsMLAPI Controls
    {
        get
        {
            if(controls != null)
            {
                return controls;
            }
            return controls = new PlayerControlsMLAPI();
        }
    }

    // Start is called before the first frame update
    public override void NetworkStart()
    {
       
        base.NetworkStart();

        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");

        characterController = GetComponent<CharacterController>();
        lookTransformPoint = transform.Find("visor").transform;
        transform.Find("visor").transform.Find("Camera").gameObject.SetActive(true); /// TODO

        if(IsLocalPlayer)
        {
            enabled = true;
            var renderColor = transform.Find("body").GetComponent<Renderer>();
            renderColor.material.SetColor("_Color", Color.green);
        } else
        {
            enabled = false;
            var renderColor = transform.Find("body").GetComponent<Renderer>();
            renderColor.material.SetColor("_Color", Color.red);
        }

        transform.position = spawnLocations[Random.Range(0,3)].transform.position;


        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => CancelMovement();

        Controls.Player.Look.performed += ctx => SetLook(ctx.ReadValue<Vector2>());
        Controls.Player.Look.canceled += ctx => CancelLook();
    }

    private void SetMovement(Vector2 inputVector) => moveInputVector = inputVector;

    private void SetLook(Vector2 lookVector) => lookInputVector = lookVector;

    private void CancelMovement() => moveInputVector = Vector2.zero;

    private void CancelLook() => lookInputVector = Vector2.zero;

    private void OnEnable() => Controls.Enable();
    private void OnDisable() => Controls.Disable();

   /*
    void OnMove(InputValue iv) {
        moveInputVector = iv.Get<Vector2>();
    }
    */
   /*
    void OnLook(InputValue iv) {
        lookInputVector = iv.Get<Vector2>();
    }*/

    // Update is called once per frame
    void Update()
    {

        if(!IsLocalPlayer)
        {
            return;
        }

        lookRotateDirection += lookInputVector.x;
        lookRotateDirection = Mathf.Clamp(lookRotateDirection, -turnSpeed, turnSpeed);
        transform.Rotate(0, lookRotateDirection * Time.deltaTime, 0);
        // The longer looking in a direction the greater the value move in that direction
        lookVerticalDirection += lookInputVector.y;
        // Set the min and max angles to be able to look vertically
        lookVerticalDirection = Mathf.Clamp(lookVerticalDirection, -maxVerticalLookAngle, maxVerticalLookAngle);
        // Rotate the player to look towards 
        lookTransformPoint.localRotation = Quaternion.Euler(-lookVerticalDirection, 0, 0);


        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        float curSpeed = moveSpeed * moveInputVector.y * Time.deltaTime;
        float strafeSpeed = moveSpeed * moveInputVector.x * Time.deltaTime;
        characterController.Move(forward * curSpeed + right * strafeSpeed);

        // If on the ground set velocity to 0 as not falling
        if(characterController.isGrounded)
        {
            velocity = 0;
        }
        else // not on the ground to have negative velocity increase by gravity over time to cause to fall.
        {
            velocity -= gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}
