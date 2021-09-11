using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Transports.UNET;
using System.Net;

public class UINetworkConnect : MonoBehaviour
{

    public Text userRole;
    public Canvas connectMenu;
    public InputField ipaddress;

    public GameObject[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        string ip = GetLocalIPAddress();
        Debug.Log(ip);
        ipaddress.text = ip;
        //ipaddress.SetTextWithoutNotify(GetLocalIPAddress());
        
    }

    public static string GetLocalIPAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

    public void StartHost()
    {
        
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ipaddress.text;
        NetworkManager.Singleton.GetComponent<UNetTransport>().ServerListenPort = 12345;
        NetworkManager.Singleton.GetComponent<UNetTransport>().ServerListenPort = 12345;
        NetworkManager.Singleton.StartHost();
        userRole.text = "Host";
        Camera.main.gameObject.SetActive(false);
        connectMenu.gameObject.SetActive(false);
    }

    public void StartClient()
    {


        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ipaddress.text;
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectPort = 12345;
        NetworkManager.Singleton.StartClient();
        userRole.text = "Client";
        Camera.main.gameObject.SetActive(false);
        connectMenu.gameObject.SetActive(false);
    }

    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
        userRole.text = "Server";
        connectMenu.gameObject.SetActive(false);
    }

    

}