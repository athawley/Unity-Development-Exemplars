using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayer : MonoBehaviour
{
    PlayerInputManager pim;
    public Canvas startCanvas;

    // Start is called before the first frame update
    void Start()
    {
        pim = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnPlayerJoined() {
        Debug.Log("Hey a player joined");
        //PlayerInput joinedPlayer = pim.JoinPlayer();
        //Debug.Log(pim.ToString());
        //joinedPlayer.transform.SetPositionAndRotation(new Vector3(0,5,-15), Quaternion.identity);
    }*/

    public void FirstJoinButtonClicked() {
        Debug.Log("First join button clicked");

        // Disable the initial game canvas
        startCanvas.gameObject.SetActive(false);

        pim.EnableJoining();

        // Add a player
        //PlayerInput joinedPlayer = pim.JoinPlayer();

        // Move player
        //joinedPlayer.transform.SetPositionAndRotation(new Vector3(0,5,-15), Quaternion.identity);

        // Set active component of canvas.
        
    }
}
