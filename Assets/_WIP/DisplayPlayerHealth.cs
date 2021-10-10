using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerHealth : MonoBehaviour
{
    public Camera cam; // The camera used as a viewport to view the enemies
    public Slider playerHealthSlider; // UI Canvas for displaying enemy UI elements onto.

    void Start()
    {
        playerHealthSlider.value = transform.GetComponentInParent<CharacterActions>().health;
    }

    void Update()
    {
        
    }

    
}
