using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // 1. Used to run coroutine to take damage over time
    IEnumerator lavaDamage;
    
    /* 2. 
    Function to take damage over time.
    Takes the damage object from the lava area.
    */
    IEnumerator damageOverTime(DamageObject dmgObj) {
        // 3. Get the player properties e.g. script with health.
        PlayerProperties pp = GetComponent<PlayerProperties>();
        // 4. Always run
        while(true) {
            // 5. Reduce current health by damage amount
            pp.health = pp.health - dmgObj.damageAmount;
            // 6. Wait for 1 second before looping.
            yield return new WaitForSeconds(1);
        }
    }

    // 7. Runs when object has collided with something
    void OnTriggerEnter(Collider col) {
        // 8. Test message to make sure collider is working
        Debug.Log("Entered damage area");
        // 9. Check if the object that was hit has the tag lava
        if(col.CompareTag("Lava")) {
            // 10. Get the damage object from the object we hit
            DamageObject dmgObj = col.GetComponent<DamageObject>();
            // 11. Create the IEnumerator to take damage over time
            lavaDamage = damageOverTime(dmgObj);
            /* 12. 
            Start the Coroutine to take damage over time 
            while in the area
            */
            StartCoroutine(lavaDamage);
        }
    }

    // 13. Check if we've left a collider
    void OnTriggerExit(Collider col) {
        // 14. Check if we left the Lava
        if(col.CompareTag("Lava")) {
            // 15. If we have stop the coroutine
            StopCoroutine(lavaDamage);
        }
    }
}