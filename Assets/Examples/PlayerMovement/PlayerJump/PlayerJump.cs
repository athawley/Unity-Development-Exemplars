using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
	// Player variables
    private CharacterController _characterController;

	// Jumping variables
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    [SerializeField] private float _jumpHeight = 5.0f;
    private bool _jumpPressed = false;
    private float _gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementJump();
    }

	// Handle the player movement and update the player on the scene.
    void MovementJump() {
    	// Check if the player is grounded
        _groundedPlayer = _characterController.isGrounded;
        if (_groundedPlayer)
        {
            _playerVelocity.y = 0f; // If they're on the ground their vertical velocity is 0.
        }

        // Changes the height position of the player..
        if (_jumpPressed && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue); // Move the player in a nice parabola for the jump
            _jumpPressed = false; // We've handled the jump so turn off the flag for the pressing of the button
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime; // Update the player velocity (decreasing over time)
        _characterController.Move(_playerVelocity * Time.deltaTime); // Move the player
    }

	// Run when the jump button is pressed
    private void OnJump() {
        Debug.Log("Jump Pressed");
        

        // If on the ground let them jump
        if(_characterController.velocity.y == 0) {
            Debug.Log("Can jump");
            _jumpPressed = true;
        } else {
            Debug.Log("Can't jump - free falling!");
        }
    }
}
