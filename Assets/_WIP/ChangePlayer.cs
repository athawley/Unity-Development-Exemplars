using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour
{
    public GameObject player;

    public Slider redSlider, greenSlider, blueSlider;

    public void Start()
    {
        //Adds a listener to the main slider and invokes a method when the value changes.
        redSlider.onValueChanged.AddListener(delegate {ChangeColourOfPlayer(); });
        greenSlider.onValueChanged.AddListener(delegate {ChangeColourOfPlayer(); });
        blueSlider.onValueChanged.AddListener(delegate {ChangeColourOfPlayer(); });
    }

    // Invoked when the value of the slider changes.
    
    public void ChangeColourOfPlayer() {
        //player = transform.Find("PlayerThirdPerson").gameObject;

        GameObject body = player.transform.Find("body").gameObject;
        player.SetActive(false);

        Material m = new Material(Resources.Load<Material>("Materials/DefaultMaterial"));
        float r, g, b;
        r = redSlider.value;
        g = greenSlider.value;
        b = blueSlider.value;
        m.color = new Color(r/256,g/256,b/256);

        body.GetComponent<Renderer>().material = m;

        player.SetActive(true);
    }
}