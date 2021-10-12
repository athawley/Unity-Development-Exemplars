using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class PathfindingOnClick : MonoBehaviour
{
    Vector3 newPosition;
    void Start () {
        newPosition = transform.position;
    }

    void OnClick() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            newPosition = hit.point;
            transform.position = newPosition;
        }
    }
    
}
