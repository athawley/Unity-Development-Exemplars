using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLocation : MonoBehaviour
{
    
    public void SavePlayerPosition() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PlayerPrefs.SetFloat("player_x_pos", player.transform.position.x);
        PlayerPrefs.SetFloat("player_y_pos", player.transform.position.y);
        PlayerPrefs.SetFloat("player_z_pos", player.transform.position.z);
    }

    public void LoadPlayerPosition() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float x = PlayerPrefs.GetFloat("player_x_pos");
        float y = PlayerPrefs.GetFloat("player_y_pos");
        float z = PlayerPrefs.GetFloat("player_z_pos");
        Vector3 loadedPosition = new Vector3(x, y, z);

        player.SetActive(false); // Disable the player object before moving
        player.transform.position = loadedPosition; // Update player position
        player.SetActive(true); // Enable player position
    }

}
