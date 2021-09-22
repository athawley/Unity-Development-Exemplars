using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovementFPS_Local : MonoBehaviour
{

    //public NetworkVariableFloat playerHealth = new NetworkVariableFloat(100f);
    public float playerHealth;
    public Text playerHealthTextBox;

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


    // Start is called before the first frame update
    public void Start()
    {
        //base.NetworkStart();

        //Debug.Log("ID: " + NetworkManager.Singleton.LocalClientId);

        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");

        characterController = GetComponent<CharacterController>();
        lookTransformPoint = transform.Find("visor").transform;
        playerHealthTextBox.text = "" + playerHealth;

        
            //enabled = true;
            transform.Find("visor").transform.Find("Camera").gameObject.SetActive(true); // visor not moving on clients.
            transform.Find("Canvas").gameObject.SetActive(true);
        
/*
        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => CancelMovement();

        Controls.Player.Look.performed += ctx => SetLook(ctx.ReadValue<Vector2>());
        Controls.Player.Look.canceled += ctx => CancelLook();

        Controls.Player.Fire.performed += ctx => SetFire();
        Controls.Player.Fire.canceled += ctx => CancelFire();
 */
        
        
        
        RespawnClientRpc();
        

    }

    void OnMove(InputValue inputValue) {
        moveInputVector = inputValue.Get<Vector2>();
    }

    void OnLook(InputValue inputValue) {
        lookInputVector = inputValue.Get<Vector2>();
    }



    //private void SetMovement(Vector2 inputVector) => moveInputVector = inputVector;
    //private void CancelMovement() => moveInputVector = Vector2.zero;

    //private void SetLook(Vector2 lookVector) => lookInputVector = lookVector;
    //private void CancelLook() => lookInputVector = Vector2.zero;
    
    //private void SetFire() {
    void OnFire() {
        //Debug.Log("Fire pressed InputAction");
        //FireServerRpc((int)NetworkManager.Singleton.LocalClientId);

        ShootServerRpc();
    }
    private void CancelFire() {}
/*
    private void OnEnable() { 
        
        //var renderColor = transform.Find("body").GetComponent<Renderer>();
        //renderColor.material.SetColor("_Color", playerColour.Value);
        Controls.Enable();
    }
    private void OnDisable() { 
        //playerColour.OnValueChanged -= OnPlayerColourChanged;
        Controls.Disable();
    }
*/
    
    void ShootServerRpc() {
        RaycastHit hit;
        Ray forwardRay = new Ray (transform.position, transform.forward);
 
        if (Physics.Raycast (forwardRay, out hit, 50.0f)) {
            if(hit.transform.gameObject.CompareTag("Player")) {
                hit.collider.GetComponentInParent<PlayerMovementFPS_Local>().TakeDamage(50);
                Debug.Log("I hit a player");
                //hit.transform.gameObject.GetComponent<Renderer>().enabled = true;
            } else {
                Debug.Log("I don't know what I hit");
            }
        }
    }

    // Take damage and update health
    public void TakeDamage(float damage) {
        playerHealth -= damage;
        if(playerHealth <= 0) { // Respawn
            playerHealth = 100;
            RespawnClientRpc(); // If the player has died respawn them.
        }
    }

    

    


    void RespawnClientRpc() {
        //StartCoroutine(RespawnPlayer());
        Vector3 position = spawnLocations[Random.Range(0,4)].transform.position;
        characterController.enabled = false;
        transform.position = position;
        characterController.enabled = true;
    }





    // Update is called once per frame, gravity, movement and look only
    void Update()
    {


        if(lookInputVector.x == 0) {
            //transform.Rotate(0, lookRotateDirection * Time.deltaTime, 0);
            lookRotateDirection = 0;
        } else {
            lookRotateDirection += lookInputVector.x;
            lookRotateDirection = Mathf.Clamp(lookRotateDirection, -turnSpeed, turnSpeed);
            transform.Rotate(0, lookRotateDirection, 0);
        }
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
