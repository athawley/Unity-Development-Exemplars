using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. Add in the Input System
using UnityEngine.InputSystem;

public class ShootProjectile : MonoBehaviour
{
    // 2. The projectile prefab that we will shoot / spawn
    public GameObject projectilePrefab;

    /* 3. 
    A variable to store the projcetile, not used here.
    This could be modified to allow only one projectile
    to be spawned at a time.
    */
    GameObject projectile;

    // 4. The point that we want to spawn / create the projectile at
    public Transform projectileSpawn;

    /* 5. 
    This is linked to the Input Actions, Make sure there
    if one called Fire in the Input Actions file.
    */
    void OnFire() {
        Debug.Log("Projectile Fire pressed"); // Debug
        /* 6.
        Create the projectile using the proJectilePrefab.
        This takes three arguments
        - the prefab to spawn
        - The position to spawn the projecting (in this case
        at the transform of the projectileSpawn variable)
        - The direction / rotation to spawn the projectile
        */
        projectile = Instantiate(projectilePrefab, projectileSpawn.transform.position, 
            projectileSpawn.transform.rotation);
    }   
}