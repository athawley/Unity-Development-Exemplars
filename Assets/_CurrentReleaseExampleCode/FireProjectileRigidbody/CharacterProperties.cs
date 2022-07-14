using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 1. 
This class is designed to be a universal helper class for
managing characters both the player and enemy objects and
handling their common functions like health and taking damage.

It must be placed on the root object of the prefab.
*/
public class CharacterProperties : MonoBehaviour
{
    // 2. The health of this object
    public float health = 50.0f;

    // 3. Function to enable taking damage, take the damage to inflict
    public void TakeDamage(float damage) {
        // 4. Update the value of health
        health = health - damage;
        // 5. If health is below 0 destroy this object
        if(health <= 0 ) {
            // 6. Destroy the object and it's children.
            Destroy(this.gameObject);
        }
    }
}
