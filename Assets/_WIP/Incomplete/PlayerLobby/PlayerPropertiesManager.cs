using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerLobbyExample {

public class PlayerPropertiesManager : MonoBehaviour
{
    public PlayerSettings settings = new PlayerSettings();
    

    public GameObject _body;
    public Renderer _bodyRenderer;
    public GameObject[] secondaryParts;
    public Renderer[] _secondaryPartsRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ConfigurePlayer(PlayerSettings ps) {

        settings = ps;
        //Debug.Log("Main Colour: " + settings.MainColour);
        UpdatePlayerColour();
        UpdatePlayerRole();
    }

    void UpdatePlayerRole() {
        //gameObject.SetActive(false);
        switch(settings.Role) {
            case "Scout":
                gameObject.transform.localScale = new Vector3(0.5f, 1.0f, 0.5f);
                break;
            case "Tank":
                gameObject.transform.localScale = new Vector3(1.5f, 1.25f, 1.25f);
                break;
            case "Damage":
                gameObject.transform.localScale = new Vector3(1f, 1.0f, 1f);
                break;
            default:
                gameObject.transform.localScale = new Vector3(1f, 1.0f, 1f);
                break;
        }
        //gameObject.SetActive(true);
    }

    void SetMainColour(Color c) {
        settings.MainColour = c;
    }

    void SetSecondaryColour(Color c) {
        settings.SecondaryColour = c;
    }

    void UpdatePlayerColour() {
        // Take player colours and update model.

        //gameObject.SetActive(false);
        _bodyRenderer.material.SetColor("_Color", settings.MainColour);

        foreach(Renderer r in _secondaryPartsRenderer) {
            r.material.SetColor("_Color", settings.SecondaryColour);
        }

        //gameObject.SetActive(true);
    }
}

}