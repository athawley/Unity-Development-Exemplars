using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine.UI;

public class PlayerShooting_MLAPI : NetworkBehaviour
{
    NetworkVariableFloat playerHealth = new NetworkVariableFloat(100f);
    public Text playerHealthTextBox;

    public void Start() {

        playerHealthTextBox.text = "" + playerHealth.Value;
    }

    public void SetFire() {
        //Debug.Log("Fire pressed InputAction");
        FireServerRpc((int)NetworkManager.Singleton.LocalClientId);

//        RaycastHit hit;
//        Ray forwardRay = new Ray (transform.position, transform.forward);
 
//        if (Physics.Raycast (forwardRay, out hit, 50.0f)) {
            //Debug.Log("Raycast created " + hit.transform.gameObject.ToString());
            /*
            Renderer r = hit.transform.GetComponent<Renderer>();
            if(r.material.color == Color.red) {
                r.material.SetColor("_Color", Color.red);
            } else {
                r.material.SetColor("_Color", Color.black);
            }*/

            

            /*
            if(hit.transform.gameObject.CompareTag("Player")) {
                //hit.transform

                hit.transform.gameObject.GetComponent<Renderer>().enabled = false;
                Renderer r = hit.transform.GetComponent<Renderer>();
                r.material.SetColor("_Color", playerColour.Value);
                Debug.Log("I hit a player");
                hit.transform.gameObject.GetComponent<Renderer>().enabled = true;
            } else {

                Debug.Log("I don't know what I hit");
            }*/
//        }
    }
    public void CancelFire() {}

    public void TakeDamage(float damage) {
        playerHealth.Value -= damage;
    }

/*
    private void OnEnable() { 
        
        Controls.Enable();
    }
    private void OnDisable() { 
        
        Controls.Disable();
    }
*/

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
                //r.material.SetColor("_Color", playerColour.Value);
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
}
