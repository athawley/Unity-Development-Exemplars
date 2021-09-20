using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEnemySeen : MonoBehaviour
{
    private bool Key;
 
    public Camera camera;

    public Color defaultColour;
    GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        //camera = GetComponent<Camera>();
        defaultColour = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //Ray forwardRay = new Ray (transform.position, transform.forward);
        Ray forwardRay = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
 
        if (Physics.Raycast (forwardRay, out hit, 50.0f)) {
            if(hit.transform.gameObject.CompareTag("Enemy")) {
                //hit.collider.GetComponentInParent<PlayerMovementFPS_MLAPI>().TakeDamage(50);
                Debug.Log("I hit a player");
                enemy = hit.transform.gameObject;
                hit.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                Key = true;
            } else {
                if(enemy != null) {
                     enemy.GetComponent<Renderer>().material.SetColor("_Color", defaultColour);
                     enemy = null;
                 }
               Debug.Log("Not hitting enemy");
                     // Hitting something else.
                     Key = false;
            
            }
        } else if (Key == true)
             {
                 // not anymore.
                 if(enemy != null) {
                     enemy.GetComponent<Renderer>().material.SetColor("_Color", defaultColour);
                     enemy = null;
                 }
                 Debug.Log("Lost enemy");
                 Key = false;
             }
    }
}

 