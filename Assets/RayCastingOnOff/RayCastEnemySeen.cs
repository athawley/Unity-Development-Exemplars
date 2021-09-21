using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEnemySeen : MonoBehaviour
{
    private bool Key;
    public Camera camera;
    public Color highlightedColor;
    GameObject enemy;

    void RayCastChangeColorOnHit() {
        RaycastHit hit;
        //Ray forwardRay = new Ray (transform.position, transform.forward);
        Ray forwardRay = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
 
        if (Physics.Raycast (forwardRay, out hit, 50.0f)) {
            if(hit.transform.gameObject.CompareTag("Enemy")) {
                //hit.collider.GetComponentInParent<PlayerMovementFPS_MLAPI>().TakeDamage(50);
                if(enemy == null) {
                    Debug.Log("I hit a player for the first time");
                    enemy = hit.transform.gameObject;
                    //highlightedColor = new Color(hit.transform.GetComponent<Renderer>().material.color.r, hit.transform.GetComponent<Renderer>().material.color.g, hit.transform.GetComponent<Renderer>().material.color.b);
                    highlightedColor = hit.transform.GetComponent<Renderer>().material.color;
                    Debug.Log(highlightedColor.ToString());
                    hit.transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    Debug.Log(highlightedColor.ToString());
                    Key = true;
                }
            } else {
                if(enemy != null) {
                     enemy.GetComponent<Renderer>().material.SetColor("_Color", highlightedColor);
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
                     enemy.GetComponent<Renderer>().material.SetColor("_Color", highlightedColor);
                     enemy = null;
                 }
                 Debug.Log("Lost enemy");
                 Key = false;
             }
    }

    // Update is called once per frame
    void Update()
    {

        RayCastChangeColorOnHit();
        
    }
}

 