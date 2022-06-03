using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeaponManager : MonoBehaviour
{
    //bool _firePressed = false;
    public Animator weaponAnimator;

    void OnFire() {
        Debug.Log("Attack Pressed");
        weaponAnimator.SetTrigger("AttackPressed");
    }
}
