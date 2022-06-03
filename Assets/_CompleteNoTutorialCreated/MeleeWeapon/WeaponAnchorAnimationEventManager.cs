using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnchorAnimationEventManager : MonoBehaviour
{

    public Animator weaponAnimator;

    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAttack() {
        weaponAnimator.SetBool("AttackPressed", true);
    }

    public void ResetParameter(string s, bool b) {
        weaponAnimator.SetBool(s, b);
    }

    public void ResetParameter(string s, float b) {
        weaponAnimator.SetFloat(s, b);
    }
/*
    public void ResetParameter(string s, int b) {
        weaponAnimator.SetInt(s, b);
    }

    public void ResetParameter(string s, string b) {
        weaponAnimator.SetString(s, b);
    }*/
}
