using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    GameObject projectile;
    public Transform projectileSpawn;

    void OnFire() {
        Debug.Log("Projectile Fire pressed");
        projectile = Instantiate(projectilePrefab, projectileSpawn.position, 
            Quaternion.identity);
        
    }

    
}
