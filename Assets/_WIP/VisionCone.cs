using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public float viewDistance; // Distance for view to work (radius of circle)

    [Range(0,360)]
    public float viewAngle; // The angle or width of the view cone (total)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public Vector3 DirectionFromAngle(float viewAngle, bool globalAngle) {
        if(!globalAngle) {
            viewAngle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(viewAngle * Mathf.Deg2Rad),0,Mathf.Cos(viewAngle * Mathf.Deg2Rad));
    }
}
