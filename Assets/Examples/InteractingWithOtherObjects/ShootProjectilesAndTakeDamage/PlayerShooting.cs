using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire() {
        Debug.Log("Fire Pressed");
        CharacterActions ca;
        if(TryGetComponent<CharacterActions>(out ca)) {
            ca.TakeDamage(10);
            ca.Shoot();
        }
    }
}
