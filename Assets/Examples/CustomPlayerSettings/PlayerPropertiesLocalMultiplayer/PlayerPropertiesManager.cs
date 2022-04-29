using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Main Colour: " + settings.MainColour);
        UpdatePlayerColour();
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
