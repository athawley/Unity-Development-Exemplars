using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BALListicsPlayerManager : MonoBehaviour
{

    CharacterController _cc;
    [SerializeField]
    float _speed = 5.0f;

    Vector2 _playerMovement;

    public Text playerIDText;
    public Transform mTransform, mTextTransform;

    public Transform spawnPoint;

    public string team;

    PlayerInput pi;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        pi = GetComponent<PlayerInput>();
        playerIDText.text = "P" + (pi.playerIndex+1);
        team = "None";
        _cc = GetComponent<CharacterController>();

        this.gameObject.SetActive(false);
        transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);
       
        BALListicsGameManager.players.Add(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        _cc.SimpleMove(new Vector3(_playerMovement.x, 0.0f, _playerMovement.y) * _speed);
        //playerIDText.gameObject.transform.SetPositionAndRotation(this.gameObject.transform.position, this.gameObject.transform.rotation);

        // Player Text above player
        Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        // add a tiny bit of height?
        screenPos.y += 2; // adjust as you see fit.
        mTextTransform.position = screenPos;
    }

    void OnMove(InputValue iv) {
        _playerMovement = iv.Get<Vector2>();
    }

    public void ChangeTeam(string t) {
        team = t;
        foreach(Renderer r in GetComponentsInChildren<Renderer>()){
            if(t == "Red") {
                r.material.color=Color.red;
            } else if(t == "Blue") {
                r.material.color=Color.blue;
            } else {
                r.material.color=Color.white;
            }
    	}
    }

    public void RespawnPlayer() {
        this.gameObject.SetActive(false);
        transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);
    }
}
