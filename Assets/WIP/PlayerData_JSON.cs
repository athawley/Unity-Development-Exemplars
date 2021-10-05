using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData_JSON : MonoBehaviour
{
    public void SavePlayer() {
        PlayerStats ps = new PlayerStats();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        ps.playerPosition = player.transform.position;
        ps.playerColour = Color.black;
        ps.playerName = "Learn ICT Now";

        string jsonData = JsonUtility.ToJson(ps);

        Debug.Log("JSON: " + jsonData);
        
        File.WriteAllText( Application.persistentDataPath + "/savefile.json" , jsonData );
    }

    public void LoadPlayer() {
        PlayerStats ps = new PlayerStats();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        string jsonFileLocation = Application.persistentDataPath + "/savefile.json";
        string jsonData = File.ReadAllText(jsonFileLocation);

        ps = JsonUtility.FromJson<PlayerStats>(jsonData);

        Debug.Log("Player name: " + ps.playerName);
        player.SetActive(false);
        player.transform.position = ps.playerPosition;
        player.GetComponentInChildren<Renderer>().material.color = ps.playerColour;
        player.SetActive(true);
    }
}