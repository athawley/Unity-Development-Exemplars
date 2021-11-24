using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableItem : MonoBehaviour
{
    public GameObject item;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider col) {
        Debug.Log("In collider area");
        textBox.enabled = true;
    }

    void OnTriggerExit(Collider col) {
        Debug.Log("Left Collider area");
        textBox.enabled = false;
    }
}
