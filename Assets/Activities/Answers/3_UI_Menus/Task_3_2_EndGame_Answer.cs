using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Task_3_2_EndGame_Answer : MonoBehaviour
{
    [SerializeField] string loadMeName;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed = 10.0f;
    public float RotationSpeed = 5.0f;
    int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //target = waypoints[0].position;
        StartCoroutine (GameOverManager());    
     
    }

    // Update is called once per frame
    void Update()
    {

    
        //values for internal use
        Quaternion _lookRotation;
        Vector3 _direction;
        
        //find the vector pointing from our position to the target
         _direction = (Vector3.zero - Camera.main.transform.position).normalized;
 
         //create the rotation we need to be in to look at the target
         _lookRotation = Quaternion.LookRotation(_direction);
 
         //rotate us over time according to speed until we are in the required rotation
         Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        
        float step =  speed * Time.deltaTime; // calculate distance to move
        Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, waypoints[targetIndex].position, step);
        if (Vector3.Distance(Camera.main.transform.position, waypoints[targetIndex].position) < 0.001f)
        {
            // Swap the position of the cylinder.
            targetIndex = targetIndex + 1;
            if(targetIndex > waypoints.Length - 1) {
                targetIndex = 0;
            }
        }

    }
    
     
     IEnumerator GameOverManager()
     {
        Debug.Log("Waiting 5 seconds");
        yield return new WaitForSeconds(5f);
        Debug.Log("Waited 5 seconds");
        SceneManager.LoadScene(loadMeName);
     }
}
