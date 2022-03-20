using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SprintWithCooldown
{
    


public class TwoCharactersOneControllerCC : MonoBehaviour
{
    public float rotate;
    public Vector2 movementAlpha, movementBeta;
    [SerializeField] CharacterController playerAlphaCC;
    [SerializeField] CharacterController playerBetaCC;

    [SerializeField] LineRenderer line;
    public float playerSpeed = 5;
    float alphaSpeed = 5;
    float betaSpeed = 5;
    bool sprintAlpha, sprintBeta, lineActive, alphaCanSprint, betaCanSprint, lineCanFire;

    // Start is called before the first frame update
    void Start()
    {
        //cc = GetComponent<CharacterController>();
        sprintAlpha = false;
        alphaCanSprint = true;
        sprintBeta = false;
        betaCanSprint = true;
        lineActive = true;
        lineCanFire = false;
        StartCoroutine(Cooldown(3f, 5, "line"));
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(movementAlpha, playerAlphaCC, alphaSpeed);
        MovePlayer(movementBeta, playerBetaCC, betaSpeed);
    }

    void MovePlayer(Vector2 movementInput, CharacterController cc, float ps) {
       Vector3 moveVector = new Vector3(movementInput.x, 0.0f, movementInput.y);
        cc.Move(moveVector * Time.deltaTime * ps);
        cc.Move(Physics.gravity * Time.deltaTime);
    }

    void OnMoveAlpha(InputValue iv) {
        movementAlpha = iv.Get<Vector2>();
    }

    void OnMoveBeta(InputValue iv) {
        movementBeta = iv.Get<Vector2>();
    }

    void OnSprintAlpha() {
        //sprintAlpha = !sprintAlpha;
        if(alphaCanSprint) {
            alphaSpeed = alphaSpeed * 2;
            alphaCanSprint = false;
            StartCoroutine(Cooldown(1.5f, 5, "alpha"));
        } else {
            //alphaSpeed = alphaSpeed / 2;
        }
    }
    
    void OnSprintBeta() {
        //sprintBeta = !sprintBeta;
        if(betaCanSprint) {
            betaSpeed = betaSpeed * 2;
            betaCanSprint = false;
            StartCoroutine(Cooldown(1.5f, 5, "beta"));
        } else {
            //betaSpeed = betaSpeed / 2;
        }
    }

    void OnConnectPlayers() {
        if(!line.gameObject.activeSelf && lineCanFire) {
            line.gameObject.SetActive(true);
            lineCanFire = false;
            StartCoroutine(Cooldown(1f, 5, "line"));
        }
    }

    IEnumerator Cooldown(float duration, float cooldownTime, string type)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(duration);

        switch(type) {
            case "line":
                line.gameObject.SetActive(false);
                break;
            case "alpha":
                alphaSpeed = alphaSpeed / 2;
                break;
            case "beta":
                betaSpeed = betaSpeed / 2;
                break;
            default:
                break;
        }

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(cooldownTime);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        switch(type) {
            case "line":
                lineCanFire = true;
                line.gameObject.SetActive(false);
                break;
            case "alpha":
                alphaSpeed = alphaSpeed / 2;
                alphaCanSprint = true;
                break;
            case "beta":
                betaSpeed = betaSpeed / 2;
                betaCanSprint = true;
                break;
            default:
                break;
        }
    }
}

}