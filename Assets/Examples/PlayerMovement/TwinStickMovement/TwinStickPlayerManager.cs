using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwinStickPlayerManager : MonoBehaviour
{
    CharacterController _cc;
    Vector2 _movementInput;
    Vector2 _lookInput;
    bool isGamepad = false;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y);
        _cc.SimpleMove(movement);

        if(isGamepad) {
            Vector3 playerDirection = Vector3.right * _lookInput.x + Vector3.forward * _lookInput.y;
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        } else {          
            Ray cameraRay = Camera.main.ScreenPointToRay(_lookInput);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }       
    }

    public void OnMove(InputValue iv)
    {
        _movementInput = iv.Get<Vector2>();
    }

    public void OnLook(InputValue iv)
    {
        _lookInput = iv.Get<Vector2>();
    }

    public void OnControlsChanged(PlayerInput pi) {
        Debug.Log(pi.currentControlScheme);
        if(pi.currentControlScheme.Equals("Gamepad")) {
            isGamepad = true;
        } else {
            isGamepad = false;
        }
    }
}