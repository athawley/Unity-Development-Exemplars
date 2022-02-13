using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementCine3rdLocalMP : MonoBehaviour
{
   private Vector2 _inputMovement;
   public float gravity = 9.8f;

   private CharacterController _cc;

   private float _velocity = 0;

   public float Speed = 3.0f;

   public Transform _mainCameraTransform;

   public float TurnSmoothTime = 0.1f;

   public Cinemachine.CinemachineInputProvider CinemachineInputProvider;
   float _turnSmoothVelocity;

   bool _sprinting = false;

   void Start() {
      _cc = GetComponent<CharacterController>();
      //_mainCameraTransform = Camera.main.transform;
      //CinemachineInputProvider.PlayerIndex = PlayerInput.
   }

   void OnMove(InputValue iv) {
      _inputMovement = iv.Get<Vector2>();
   }

   void OnFire() {
      _sprinting = !_sprinting;
      if(_sprinting) {
         Speed = Speed * 2;
      } else {
         Speed = Speed / 2;
      }
   }


   // Update is called once per frame
   void Update()
   {
      Vector3 tempMove = new Vector3(_inputMovement.x, 0.0f, _inputMovement.y).normalized;

      if(tempMove.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(tempMove.x, tempMove.z) * Mathf.Rad2Deg + _mainCameraTransform.eulerAngles.y;
            float turnAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _cc.Move(moveDir.normalized * Speed * Time.deltaTime);
      }

      // If on the ground set velocity to 0 as not falling
      if(_cc.isGrounded)
      {
         _velocity = 0;
      }
      else // not on the ground to have negative velocity increase by gravity over time to cause to fall.
      {
         _velocity -= gravity * Time.deltaTime;
         _cc.Move(new Vector3(0, _velocity, 0));
      }
   }
}
