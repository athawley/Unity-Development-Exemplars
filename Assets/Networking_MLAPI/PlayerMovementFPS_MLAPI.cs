using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class PlayerMovementFPS_MLAPI : NetworkBehaviour
{
    // Player Colour
    //[SerializeField]
    //private NetworkVariableColor32 playerColour { get; set; } = new NetworkVariableColor32();

    //public NetworkVariableColor32 PlayerColour => playerColour;

    Color32 localPlayerColour;

    //List<NetworkVariableColor32> playerColours  { get; set; } = new List<NetworkVariableColor32>();

    NetworkVariableColor32 playerColour = new NetworkVariableColor32();


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

        if(IsLocalPlayer)
        {
            enabled = true;
            //Cursor.lockState = CursorLockMode.Locked;
            transform.Find("visor").transform.Find("Camera").gameObject.SetActive(true);
            

        } else
        {
            enabled = false;
            //var renderColor = transform.Find("body").GetComponent<Renderer>();
            //renderColor.material.SetColor("_Color", playerColour.Value);
        }

        Controls.Player.Move.performed += ctx => SetMovement(ctx.ReadValue<Vector2>());
        Controls.Player.Move.canceled += ctx => CancelMovement();

        Controls.Player.Look.performed += ctx => SetLook(ctx.ReadValue<Vector2>());
        Controls.Player.Look.canceled += ctx => CancelLook();
 
        /// TODO: Will generate, new clients do not show with updated colours on existing players / clients. e.g. host doesn't see colours.
        //SetPlayerColourServerRpc(new Color32((byte)Random.Range(0,255),(byte)Random.Range(0,255),(byte)Random.Range(0,255),1));
        if(IsOwner) {
            SetPlayerColourServerRpc(new Color32((byte)Random.Range(0,255),(byte)Random.Range(0,255),0,1));
        }
        
        RespawnClientRpc(spawnLocations[Random.Range(0,3)].transform.position);
        //NetworkManager.
    }


    private void SetMovement(Vector2 inputVector) => moveInputVector = inputVector;

    private void SetLook(Vector2 lookVector) => lookInputVector = lookVector;

    private void CancelMovement() => moveInputVector = Vector2.zero;

    private void CancelLook() => lookInputVector = Vector2.zero;

    //private void OnEnable() => Controls.Enable();
    //private void OnDisable() => Controls.Disable();

    private void OnEnable() { 
        playerColour.OnValueChanged += OnPlayerColourChanged;
        Controls.Enable();
    }
    private void OnDisable() { 
        playerColour.OnValueChanged -= OnPlayerColourChanged;
        Controls.Disable();
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
    void RespawnClientRpc(Vector3 position) {
        /*transform.Find("body").gameObject.GetComponent<Renderer>().enabled = false;
        var renderColor = transform.Find("body").GetComponent<Renderer>();
        renderColor.material.SetColor("_Color", new Color32((byte)Random.Range(0,255), (byte)Random.Range(0,255), (byte)Random.Range(0,255), 1));
        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = true;*/
        
        //var renderColor = transform.Find("body").GetComponent<Renderer>();
        //renderColor.material.SetColor("_Color", new Color(Random.Range(100,200),Random.Range(0,200),Random.Range(0,155)));
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
/*
    void Start() {
        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = false;
        var renderColor = transform.Find("body").GetComponent<Renderer>();
        //renderColor.material.SetColor("_Color", playerColour.Value);
        transform.Find("body").gameObject.GetComponent<Renderer>().enabled = true;
    }
*/
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
