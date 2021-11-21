using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    public bool correct = false;
    // Start is called before the first frame update
    void Start()
    {
        //print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    Detect if the Answerbox has collided with the player
    */
    void OnTriggerEnter(Collider other) {
        //Debug.Log("Collided");
        if(other.CompareTag("Player") == true) {
            // Collided with the player
            //Debug.Log("Player Hit");
            
            Material temp = GetComponent<Renderer>().material;
            if(correct) {
                //Debug.Log("Correct");
                //temp = Resources.Load("Examples/Dynamically Check Objects/Correct", typeof(Material)) as Material;
                temp.color = Color.green;
            } else {
                //Debug.Log("Wrong");
                //temp = Resources.Load("Examples/Dynamically Check Objects/Correct", typeof(Material)) as Material;
                temp.color = Color.red;
            }
            //GetComponent<Renderer>().material = temp;
        }
    }
}
