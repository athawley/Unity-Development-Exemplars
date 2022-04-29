using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerLobbyExample {

public class PlayerSelectManager : MonoBehaviour
{
    public GameObject playerPlaceholder;
    public ToggleGroup MainColourGroup, SecondaryColourGroup, PlayStyleGroup;

    void Start() {
        UpdatePlayer();
    }

    public void UpdatePlayer() {
        PlayerSettings ps = new PlayerSettings();
        foreach(Toggle t in MainColourGroup.ActiveToggles()) {
            switch(t.name) {
                case "ToggleRed":
                    ps.MainColour = Color.red;
                    break;
                case "ToggleGreen":
                    ps.MainColour = Color.green;
                    break;
                case "ToggleBlue":
                    ps.MainColour = Color.blue;
                    break;
                default:
                    break;
            }
        }

        foreach(Toggle t in SecondaryColourGroup.ActiveToggles()) {
            switch(t.name) {
                case "ToggleYellow":
                    ps.SecondaryColour = Color.yellow;
                    break;
                case "ToggleGrey":
                    ps.SecondaryColour = Color.grey;
                    break;
                case "TogglePink":
                    ps.SecondaryColour = Color.magenta;
                    break;
                default:
                    break;
            }
        }

        foreach(Toggle t in PlayStyleGroup.ActiveToggles()) {
            switch(t.name) {
                case "ToggleScout":
                    ps.Role = "Scout";
                    break;
                case "ToggleTank":
                    ps.Role = "Tank";
                    break;
                case "ToggleDamage":
                    ps.Role = "Damage";
                    break;
                default:
                    break;
            }
        }

        playerPlaceholder.GetComponent<PlayerPropertiesManager>().ConfigurePlayer(ps);
        
    }
}

}