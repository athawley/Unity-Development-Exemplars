using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;

public class UINetworkConnect : MonoBehaviour
{

    public Text userRole;
    public Canvas connectMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        userRole.text = "Host";
        connectMenu.gameObject.SetActive(false);
    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        userRole.text = "Client";
        connectMenu.gameObject.SetActive(false);
    }

    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
        userRole.text = "Server";
        connectMenu.gameObject.SetActive(false);
    }



}