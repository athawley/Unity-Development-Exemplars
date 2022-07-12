using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    IEnumerator damageObject;
    public float damageAmount = 10;
    void OnTriggerEnter(Collider col) {
        Debug.Log("Entered damage area");
        try {
            PlayerProperties pp = col.GetComponent<PlayerProperties>();
            //pp.health = pp.health - damageAmount;
            damageObject = damageOverTime(pp);
            StartCoroutine(damageObject);
        } catch {
            Debug.Log("Player Properties not found");
        }
    }

    void OnTriggerExit(Collider col) {
        try {
            PlayerProperties pp = col.GetComponent<PlayerProperties>();
            //pp.health = pp.health - damageAmount;
            StopCoroutine(damageObject);
        } catch {
            Debug.Log("Player Properties not found");
        }
    }

    IEnumerator damageOverTime(PlayerProperties pp) {
        while(true) {
            
            pp.health = pp.health - damageAmount;
            yield return new WaitForSeconds(1);
        }
    }
}
