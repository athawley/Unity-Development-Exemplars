using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserTower : MonoBehaviour
{
    // 1. Origin point for the laser to raycast from.
    [SerializeField]
    private Transform laserOrigin, laserTarget;

    public GameObject laserLine;

    [SerializeField]
    private List<GameObject> potentialTargets;

    IEnumerator fireLaser;

    // 2. variables for the damage of the laser and the delay between shots.
    public float laserDamage = 5.0f, laserDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        laserTarget = laserOrigin;
        fireLaser = FireTowerWeapon(laserDelay);
        // 12. Start the coroutine to repeatedly
        StartCoroutine(fireLaser);
    }

    IEnumerator FireTowerWeapon(float delay) {
        while (true)
        {
            
            yield return new WaitForSeconds(delay);
            
            DrawLaserLine();
        }
    }


    void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            Debug.Log("Player is in range");
            potentialTargets.Add(col.gameObject);
            //Debug.DrawLine(laserOrigin.position, col.transform.position, Color.red, 1.0f);

            //DrawLaserLine(laserOrigin.position, col.transform.position);
            //laserTarget = col.transform;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.CompareTag("Player")) {
            Debug.Log("Player left range");
            potentialTargets.Remove(col.gameObject);
        }
    }

    void DrawLaserLine(Vector3 origin, Vector3 target) {
        LineRenderer lr = laserLine.GetComponent<LineRenderer>();
        lr.SetPosition(0, origin);
        lr.SetPosition(1, target);
    }

    void DrawLaserLine() {
        LineRenderer lr = laserLine.GetComponent<LineRenderer>();
        Vector3 target = laserOrigin.position;
        if(potentialTargets.Count > 0) {
            target = potentialTargets[0].transform.position;
        }

        lr.SetPosition(0, laserOrigin.position);
        lr.SetPosition(1, target);
    }

}
