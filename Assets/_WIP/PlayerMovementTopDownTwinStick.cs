using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementTopDownTwinStick : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    
    [SerializeField] private bool isGamepad;

    private Vector2 movement;
    private Vector2 lookDirection;
    private Vector3 playerVelocity;

    [SerializeField] CharacterController cc;

    public GameObject playerBody;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        //playerBody = gameObject.get
        //playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(movement.x, 0.0f, movement.y);
        cc.Move(moveVector * Time.deltaTime * playerSpeed);
        cc.Move(Physics.gravity * Time.deltaTime);
        
        Vector3 playerLookDirection = new Vector3(lookDirection.x, 0, lookDirection.y);

        // Rotation
        if(isGamepad) {
            Vector3 playerDirection = Vector3.right * lookDirection.x + Vector3.forward * lookDirection.y;
            //Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            //playerBody.transform.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, newRotation, playerSpeed * Time.deltaTime);
            playerBody.transform.LookAt(playerBody.transform.position + playerLookDirection, Vector3.up);
        } else {
            Ray rayMousePointInWorld = Camera.main.ScreenPointToRay(lookDirection);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if(groundPlane.Raycast(rayMousePointInWorld, out rayDistance)) {
                Vector3 mousePosition = rayMousePointInWorld.GetPoint(rayDistance);
            
                playerBody.transform.LookAt(mousePosition);
            }
        }
 
        //playerBody.transform.rotation = Quaternion.Euler(playerLookDirection);

        //playerBody.transform.LookAt(playerBody.transform.position + playerLookDirection, -Vector3.forward);
        //transform.Rotate(playerLookDirection);
        //playerRB.MovePosition(moveVector);
        
    }

    void OnControlsChanged(PlayerInput pi) {
        isGamepad = pi.currentControlScheme.Equals("Gamepad") ? true : false;
    }

    void OnMove(InputValue iv) {
        movement = iv.Get<Vector2>();
    }

    void OnLook(InputValue iv) {
        lookDirection = iv.Get<Vector2>();
    }
}
