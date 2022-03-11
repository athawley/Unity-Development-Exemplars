using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class SetDestination : MonoBehaviour
{

    Vector3 targetPosition;
    void Start () {
        targetPosition = transform.position;
    }

    void OnClick() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
            transform.position = targetPosition;
        }
    }
    
}