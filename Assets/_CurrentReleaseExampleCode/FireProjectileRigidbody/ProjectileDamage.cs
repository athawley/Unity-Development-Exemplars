using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProjectileDamage : MonoBehaviour
{
    // 1. The damage the bullet will do on impact
    public float damage = 15;

    // 2. The amount of time the bullet wil
    public float lifeTime = 2.0f;
    
    // 3. Set the velocity for the projectile
    public float launchVelocity = 1000f;

    // 4. IEnumerator for bullet, will destroy after two seconds.
    IEnumerator bulletTimer;

    // 5. Get the layermask that we want this object to interact with
    public LayerMask layerMask;
    // 6. This stores the value of the layermask to improve code efficiency
    public int damageLayer;

    void Start() {  
        // 7. Get the index value of the layer.
        damageLayer = Mathf.RoundToInt(Mathf.Log(layerMask.value, 2));
        /* 8. 
        Apply a force to the projectile and move it at the 
        velocity specified o nthe z axis (away from the player)
        Note we haven't spawned / instantiated the object here,
        we will do that on the player when they press the fire 
        button.
        */
        this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, launchVelocity));   
        // 17. Create the IEnumerator for the coroutine
        bulletTimer = bulletLifeTimer(lifeTime);
        // 18. Start the bullet timer coroutine.
        //StartCoroutine(bulletTimer);
    }
    
    /* 14. 
    This is for the coroutine that will destroy the bullet
    after a set period of time
    */
    IEnumerator bulletLifeTimer(float time) {
        // 15. Yield control of the program and wait for the set period of time
        yield return new WaitForSeconds(time);
        // 16. Destroy the projectile
        Destroy(this.gameObject);
    }

    // 9. This is used to handle checking what the projectile has hit.
    void OnTriggerEnter(Collider col) {
        /* 10. 
        Check if the projectile collided with an object 
        with the specified layer (damageable)
        */
        if(col.gameObject.layer == damageLayer) {
            Debug.Log("Hit damageable object!");  //Debug
            /* 11. 
            Really useful get the top level object from the prefab
            that was hit.
            This us useful as the CharacterProperties is only on
            the root object.
            */
            GameObject go = col.transform.root.gameObject;
            Debug.Log(go); //Debug
            /* 12. 
            Get the CharacterProperties script and run the
            TakeDamage function which we pass the bullets damage variable
            */
            go.GetComponent<CharacterProperties>().TakeDamage(damage);
            // 13. Destroy the bullet / projectile
            Destroy(this.gameObject);
        }
    }
}
