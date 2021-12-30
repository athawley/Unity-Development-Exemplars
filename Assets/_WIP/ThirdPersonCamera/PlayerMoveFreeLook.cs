using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveFreeLook : MonoBehaviour
{
   private float _rotate;
   private float _verticalLook;
   private Vector2 _movement;
   private CharacterController _cc;
   public float PlayerSpeed = 5;
   public float RotationSpeed = 75;
   public float MaxVerticalLookAngle = 90.0f;
   public float MinVerticalLookAngle = 0.0f;
   private float _lookVerticalDirection = 0; // Where the character is looking

   [SerializeField] Camera _currentCamera;

   // Start is called before the first frame update
   void Start()
   {
      _cc = GetComponent<CharacterController>();
   }

   // Update is called once per frame
   void Update()
   {
      MovePlayer();
      RotatePlayer();
      VerticalLook();
   }

   void MovePlayer() {

      Vector3 forward = transform.TransformDirection(Vector3.forward);
      Vector3 right = transform.TransformDirection(Vector3.right);
      float curSpeed = PlayerSpeed * _movement.y * Time.deltaTime;
      float strafeSpeed = PlayerSpeed * _movement.x * Time.deltaTime;
      _cc.Move(forward * curSpeed + right * strafeSpeed);

      _cc.Move(Physics.gravity * Time.deltaTime);
   }

   void RotatePlayer() {
      transform.Rotate(Vector3.up * _rotate * RotationSpeed * Time.deltaTime);
   }

   void VerticalLook() {
      // Quaternion.LookRotation(transform.forward, transform.up);
      // float yLookPos = Mathf.Clamp(_verticalLook, 0, MaxVerticalLookAngle);
      // _currentCamera.transform.RotateAround(transform.position, transform.right, yLookPos);
 
      //_lookVerticalDirection += _verticalLook;

      //_lookVerticalDirection = Mathf.Clamp(_lookVerticalDirection, -MaxVerticalLookAngle, MaxVerticalLookAngle);
        // Rotate the player to look towards 
        //transform.localRotation = Quaternion.Euler(-lookVerticalDirection, 0, 0);
      //transform.localRotation = Quaternion.Euler(-_lookVerticalDirection, 0, 0);
      //_currentCamera.transform.RotateAround(transform.position, transform.right, _lookVerticalDirection);

      //_lookVerticalDirection = Mathf.Clamp(_verticalLook, -MaxVerticalLookAngle, MaxVerticalLookAngle);
      //float eulerAngle = Quaternion.Euler()
      
      float viewRangeDegrees = Mathf.Clamp(_currentCamera.transform.localEulerAngles.x + _verticalLook, MinVerticalLookAngle, MaxVerticalLookAngle);
      Debug.Log(viewRangeDegrees);
      if(viewRangeDegrees >= MinVerticalLookAngle && viewRangeDegrees <= MaxVerticalLookAngle) {
         _currentCamera.transform.RotateAround(transform.position, transform.right, _verticalLook);
      }
      
      
   }

   void OnMove(InputValue iv) {
      _movement = iv.Get<Vector2>();
   }

   void OnLook(InputValue iv) {
      _rotate = iv.Get<Vector2>().x;
      _verticalLook = iv.Get<Vector2>().y;
   }
}
