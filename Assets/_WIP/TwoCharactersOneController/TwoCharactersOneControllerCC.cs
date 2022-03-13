using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TwoCharactersOneControllerCC : MonoBehaviour
{
    public float rotate;
    public Vector2 movementAlpha, movementBeta;
    [SerializeField] CharacterController playerAlphaCC;
    [SerializeField] CharacterController playerBetaCC;
    public float playerSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(movementAlpha, playerAlphaCC);
        MovePlayer(movementBeta, playerBetaCC);
    }

    void MovePlayer(Vector2 movementInput, CharacterController cc) {
       Vector3 moveVector = new Vector3(movementInput.x, 0.0f, movementInput.y);
        cc.Move(moveVector * Time.deltaTime * playerSpeed);
        cc.Move(Physics.gravity * Time.deltaTime);
    }

    void OnMove(InputValue iv) {
        movementAlpha = iv.Get<Vector2>();
    }

    void OnLook(InputValue iv) {
        movementBeta = iv.Get<Vector2>();
    }
}
