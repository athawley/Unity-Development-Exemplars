using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHit : MonoBehaviour
{
    public Camera cam; // The camera used as a viewport to view the enemies
    public Slider playerHealthSlider; // UI Canvas for displaying enemy UI elements onto.

    void Start()
    {
        playerHealthSlider.value = transform.GetComponent<CharacterActions>().health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
      if(other.CompareTag("Projectile")) {
          playerHealthSlider.value = transform.GetComponent<CharacterActions>().health;
      }
    }
}
