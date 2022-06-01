using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeaponManager : MonoBehaviour
{
    bool _firePressed = false;
    public Animator weaponAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire() {
        Debug.Log("Attack Pressed");
        weaponAnimator.SetTrigger("AttackPressed");
    }
}
