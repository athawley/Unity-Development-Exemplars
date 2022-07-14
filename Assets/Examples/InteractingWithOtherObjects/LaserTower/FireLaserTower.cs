using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserTower : MonoBehaviour
{
    /* 1. 
    Origin point for the laser to raycast from.
    Also origin draw point for drawing a line
    */
    [SerializeField]
    private Transform laserOrigin;

    public GameObject laserLine;

    [SerializeField]
    private List<GameObject> potentialTargets;

    IEnumerator fireLaser;

    // 2. variables for the damage of the laser and the delay between shots.
    public float laserDamage = 5.0f, laserDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 21. Set the laser to fire (draw line) with the delay set
        fireLaser = FireTowerWeapon(laserDelay);
        // 22. Start the coroutine to repeatedly fire
        StartCoroutine(fireLaser);
    }

    // 6. Check if a object tagged Player has entered the area.
    void OnTriggerEnter(Collider col) {
        // 7. Check if object is tagged as a player
        if(col.CompareTag("Player")) {
            Debug.Log("Player is in range");
            // 8. Add the object to a list of targets
            potentialTargets.Add(col.gameObject);
        }
    }

    // 9. Check if the object has left the lasers range
    void OnTriggerExit(Collider col) {
        // 10. Check if it's one we care about tagged Player
        if(col.CompareTag("Player")) {
            Debug.Log("Player left range");
            /* 11. 
            Remove the object from the list as it is not out of the 
            range of the laser.
            */
            potentialTargets.Remove(col.gameObject);
        }
    }

    // 3. Function to use with coroutine to fire weapon with delay
    IEnumerator FireTowerWeapon(float delay) {
        // 4. Fire indefinitely, could add initial random delay here.
        while (true)
        {
            // 5. Wait delay seconds before firing
            yield return new WaitForSeconds(delay);   
            // 20. Draw the line
            DrawLaserLine();
        }
    }
    
    // 12. Draw the line and inflict damage to the object
    void DrawLaserLine() {
        // 13. Create a line renderer object (must be attached to the gameobject)
        LineRenderer lr = laserLine.GetComponent<LineRenderer>();
        /* 14.
        Set the target to be the origin initially.
        For testing put in a random vector3 set of coordinates.
        */
        Vector3 target = laserOrigin.position;

        // 15. Check if there are valid targets (tagged Player)
        if(potentialTargets.Count > 0) {
            /* 16.
            Get the first target in the list's position
            Set this position as the target for the laser
            We use the item at position [0] as this is the 
            first item that entered the range of the laser.
            */
            target = potentialTargets[0].transform.position;

            /* 17 
            Inflict damage on player
            This assumes the object has a PlayerProperties script
            component attached with a public health variable.
            */
            PlayerProperties pp = potentialTargets[0].GetComponent<PlayerProperties>();
            pp.health = pp.health - laserDamage;
        }

        // 18. Set the start position of the line to render
        lr.SetPosition(0, laserOrigin.position);
        // 19. Set the end position of the line to render
        lr.SetPosition(1, target);
    }
}
