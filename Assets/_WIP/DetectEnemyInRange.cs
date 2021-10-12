using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyInRange : MonoBehaviour
{
    public float stopDistance = 1; // Object will stop chasing at this point
    public float chaseDistance = 4; // Object will chase from this point.

    public string[] detectionTags; // array of tags that are to be detected

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, chaseDistance);
        foreach (Collider hitCollider in hitColliders)
        {
            if(hitCollider.transform.position == transform.position) {
                continue;
            }
            //hitCollider.SendMessage("In Range");

            if(hitCollider.CompareTag("Enemy")) {
                Debug.Log("In range: " + hitCollider.gameObject.ToString());
                
            }
        }
    }
}
