using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BALListicsPlayerManager : MonoBehaviour
{
    CharacterController _cc;
    [SerializeField]
    float _speed = 5.0f;

    Vector2 _playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _cc.SimpleMove(new Vector3(_playerMovement.x, 0.0f, _playerMovement.y) * _speed);
    }

    void OnMove(InputValue iv) {
        _playerMovement = iv.Get<Vector2>();
    }
}
