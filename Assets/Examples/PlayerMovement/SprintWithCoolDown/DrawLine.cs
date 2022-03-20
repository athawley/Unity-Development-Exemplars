using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SprintWithCooldown
{
    


public class DrawLine : MonoBehaviour
{
    // Apply these values in the editor
    public LineRenderer LineRenderer;
    public Transform TransformOne;
    public Transform TransformTwo;

    public Vector3 offset = new Vector3(0, 5f, 0);
 
    void Start()
    {
        // set the color of the line
        //LineRenderer.startColor = Color.red;
        //LineRenderer.endColor = Color.red;
 
        // set width of the renderer
        LineRenderer.startWidth = .25f;
        LineRenderer.endWidth = .25f;
    }

    void Update() {
 
        // set the position
        LineRenderer.SetPosition(0, new Vector3(TransformOne.position.x, TransformOne.position.y + 1, TransformOne.position.z));
        LineRenderer.SetPosition(1, new Vector3(TransformTwo.position.x, TransformTwo.position.y + 1, TransformTwo.position.z));
    }
}

}