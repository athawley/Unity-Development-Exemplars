using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpStandAlone : MonoBehaviour
{

   public float velocity = 0;
   public float gravity = 9.8f;
   public float jumpHeight = 4;
   public CharacterController characterController;

   void Start() {
        characterController = GetComponent<CharacterController>();
    }

   void Update()
   {
      MovementJump();
   }

   void OnJump() {
        
        if(characterController.isGrounded) {
            velocity = Mathf.Sqrt(jumpHeight * (gravity));
            Debug.Log("Jump pressed");
        } else {
            Debug.Log("Jump not allowed");
        }
    }

    void MovementJump() {
       
      velocity -= jumpHeight * gravity * Time.deltaTime;
      characterController.Move(new Vector3(0, velocity, 0));
      if(characterController.isGrounded) {
         velocity = 0;
      }
      
    }
}