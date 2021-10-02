using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleEnemyManager : MonoBehaviour
{
    public Transform target;
    public Camera cam;

    void Start()
    {
        //cam = GetComponent<Camera>();
    }

    void Update()
    {
        
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
        Debug.Log("target is " + screenPos.y + " pixels from the top");
    }
}
