using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine.UI;

public class PlayerMovementFPS_MLAPI : NetworkBehaviour
{

    public NetworkVariableFloat playerHealth = new NetworkVariableFloat(100f);
    public Text playerHealthTextBox;
    
    public NetworkVariableColor32 playerColour = new NetworkVariableColor32(new NetworkVariableSettings {WritePermission = NetworkVariablePermission.ServerOnly, ReadPermission = NetworkVariablePermission.Everyone});


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
        //Text userText = transform.Find("Canvas").gameObject.transform.Find("UserRole").GetComponent<Text>();
        //userText.text = "Her there";
        Debug.Log("ID: " + NetworkManager.Singleton.LocalClientId);

        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");

        characterController = GetComponent<CharacterController>();
        lookTransformPoint = transform.Find("visor").transform;
        playerHealthTextBox.text = "" + playerHealth.Value;

        if(IsLocalPlayer)
        {
            enabled = true;
            transform.Find("visor").transform.Find("Camera").gameObject.SetActive(true); // visor not moving on clients.
            transform.Find("Canvas").gameObject.SetActive(true);
        } else
        {
            enabled = false;
            
        }

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => CancelMovement();

        Controls.Player.Look.performed += ctx => SetLook(ctx.ReadValue<Vector2>());
        Controls.Player.Look.canceled += ctx => CancelLook();

        Controls.Player.Fire.performed += ctx => SetFire();
        Controls.Player.Fire.canceled += ctx => CancelFire();
 
        if(IsOwner) {
            SetPlayerColourServerRpc(new Color32((byte)Random.Range(0,255),(byte)Random.Range(0,255),(byte)Random.Range(0,255),1));
        } else {
            var renderColor = transform.Find("body").GetComponent<Renderer>();
            renderColor.material.SetColor("_Color", playerColour.Value);
        }
        
        
        
        RespawnClientRpc();
        //NetworkManager.


    }


    private void SetMovement(Vector2 inputVector) => moveInputVector = inputVector;
    private void CancelMovement() => moveInputVector = Vector2.zero;

    private void SetLook(Vector2 lookVector) => lookInputVector = lookVector;
    private void CancelLook() => lookInputVector = Vector2.zero;
    
    private void SetFire() {
        //Debug.Log("Fire pressed InputAction");
        //FireServerRpc((int)NetworkManager.Singleton.LocalClientId);

        ShootServerRpc();
    }
    private void CancelFire() {}

    //private void OnEnable() => Controls.Enable();
    //private void OnDisable() => Controls.Disable();

    private void OnEnable() { 
        playerColour.OnValueChanged += OnPlayerColourChanged;
        playerHealth.OnValueChanged += OnPlayerHealthChanged;
        //var renderColor = transform.Find("body").GetComponent<Renderer>();
        //renderColor.material.SetColor("_Color", playerColour.Value);
        Controls.Enable();
    }
    private void OnDisable() { 
        //playerColour.OnValueChanged -= OnPlayerColourChanged;
        Controls.Disable();
    }

    [ServerRpc]
    void ShootServerRpc() {
        RaycastHit hit;
        Ray forwardRay = new Ray (transform.position, transform.forward);
 
        if (Physics.Raycast (forwardRay, out hit, 50.0f)) {
            if(hit.transform.gameObject.CompareTag("Player")) {
                //hit.transform

                //hit.transform.gameObject.GetComponent<Renderer>().enabled = false;
                //Renderer r = hit.transform.GetComponent<Renderer>();
                //r.material.SetColor("_Color", playerColour.Value);

                hit.collider.GetComponentInParent<PlayerMovementFPS_MLAPI>().TakeDamage(50);

                Debug.Log("I hit a player");
                hit.transform.gameObject.GetComponent<Renderer>().enabled = true;
            } else {

                Debug.Log("I don't know what I hit");
            }
        }
    }

    [ServerRpc]
    void FireServerRpc(int firedBy) {
        if(firedBy > 0) {
            firedBy--;
        }
        Debug.Log("Server is " + NetworkManager.LocalClientId + ". " + firedBy + " told me they have shot.");
        RaycastHit hit;

        Transform source = NetworkManager.Singleton.ConnectedClientsList[firedBy].PlayerObject.transform;
        Transform target = NetworkManager.Singleton.ConnectedClientsList[firedBy].PlayerObject.transform;

        Ray forwardRay = new Ray (source.position, source.forward);
 
        if (Physics.Raycast (forwardRay, out hit, 50.0f)) {

            if(hit.transform.gameObject.CompareTag("Player")) {
                    //hit.transform

                hit.transform.gameObject.GetComponent<Renderer>().enabled = false;
                Renderer r = hit.transform.GetComponent<Renderer>();
                r.material.SetColor("_Color", playerColour.Value);
                Debug.Log("Player " + firedBy + " - " + hit.transform.gameObject.ToString());
                hit.transform.gameObject.GetComponent<Renderer>().enabled = true;

                //int hitID = (int)hit.transform.GetComponent<NetworkObject>().NetworkManager.LocalClientId;

                //Debug.Log("Player" + hitID + " was hit by " + firedBy);

                // Update all clients
                
            } else {

                Debug.Log("I don't know what I hit");
            }
        }
    }

    public void TakeDamage(float damage) {
        playerHealth.Value -= damage;
        UpdateUIClientRpc();
        if(playerHealth.Value <= 0) { // Respawn
            playerHealth.Value = 100;
            RespawnClientRpc();
        }
    }

    [ClientRpc]
    void UpdateUIClientRpc() {
        //playerHealthTextBox.text = "" + playerHealth.Value;
    }

    [ClientRpc]
    void FireClientRpc() {

    }

    [ClientRpc]
    void HitClientRpc(int id) {
    /*    go.GetComponent<Renderer>().enabled = false;
        Renderer r = go.GetComponent<Renderer>();
        r.material.SetColor("_Color", playerColour.Value);
        Debug.Log("Player " + NetworkManager.Singleton.LocalClientId);
        go.GetComponent<Renderer>().enabled = true;*/
    }

    private void OnPlayerHealthChanged(float oldValue, float newValue) {
        if(!IsClient) {
            return;
        }
        playerHealthTextBox.text = "" + playerHealth.Value;
    }

    //void OnPlayerColourChanged(Color32 oldColour, Color32 newColour) {
    private void OnPlayerColourChanged(Color32 oldColour, Color32 newColour) {
        if(!IsClient) {
            return;
        }

        // Update Renderer
        
        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = false;
        var renderColor = transform.Find("body").GetComponent<Renderer>();
        renderColor.material.SetColor("_Color", newColour);
        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = true;
        
    }

    [ServerRpc]
    public void SetPlayerColourServerRpc(Color32 col) {
        playerColour.Value = col;
    }

    [ClientRpc]
    void RespawnClientRpc() {
        
        //StartCoroutine(RespawnPlayer());
        Vector3 position = spawnLocations[Random.Range(0,4)].transform.position;
        characterController.enabled = false;
        transform.position = position;
        characterController.enabled = true;

    }

    IEnumerator RespawnPlayer() {
        Vector3 position = spawnLocations[Random.Range(0,4)].transform.position;
        yield return new WaitForSeconds(1f);
        characterController.enabled = false;
        transform.position = position;
        characterController.enabled = true;
    }

    [ClientRpc]
    void ChangeColourClientRpc(Color32 c) {
        /*if(IsOwner) {
            return;
        }*/

        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = false;
        var renderColor = transform.Find("body").GetComponent<Renderer>();
        renderColor.material.SetColor("_Color", c);
        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = true;
    }
    

   /*
    void OnMove(InputValue iv) {
        moveInputVector = iv.Get<Vector2>();
    }
    */
   /*
    void OnLook(InputValue iv) {
        lookInputVector = iv.Get<Vector2>();
    }*/

    void Awake() {
        if(!IsLocalPlayer)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(!IsLocalPlayer)
        {
            return;
        }

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
