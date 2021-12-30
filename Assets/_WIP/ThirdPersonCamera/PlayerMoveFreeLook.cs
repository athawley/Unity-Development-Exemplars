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

   private Transform _cameraTransform;

   

   // Start is called before the first frame update
   void Start()
   {
      _cc = GetComponent<CharacterController>();
      _cameraTransform = Camera.main.transform;
   }

   // Update is called once per frame
   void Update()
   {
      MovePlayer();
      RotatePlayer();
      //VerticalLook();
   }

   void MovePlayer() {

      Vector3 movement = new Vector3(_movement.x, 0.0f, _movement.y);
      
      movement = _cameraTransform.forward * movement.z + _cameraTransform.right * movement.x;
      movement.y = 0.0f;
      
      _cc.Move(movement * Time.deltaTime * PlayerSpeed);

      _cc.Move(Physics.gravity * Time.deltaTime);
   }

   void RotatePlayer() {
      //transform.Rotate(Vector3.up * _rotate * RotationSpeed * Time.deltaTime);
      float playerTargetAngle = Mathf.Atan2(_movement.x, _movement.y) * Mathf.Rad2Deg + _cameraTransform.eulerAngles.y;
      Quaternion playerRotation = Quaternion.Euler(0.0f, playerTargetAngle, 0.0f);
      transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, Time.deltaTime * RotationSpeed);
   }

   
   void OnMove(InputValue iv) {
      _movement = iv.Get<Vector2>();
   }

   void OnLook(InputValue iv) {
      _rotate = iv.Get<Vector2>().x;
      _verticalLook = iv.Get<Vector2>().y;
   }
}
