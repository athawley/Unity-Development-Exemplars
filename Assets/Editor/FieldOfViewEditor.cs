using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(VisionCone))]
public class FieldOfViewEditor : Editor
{

    void OnSceneGUI()
    {
        VisionCone viewCone = (VisionCone)target;
        Handles.color = Color.red; 
        Vector3 viewAngleA = viewCone.DirectionFromAngle(-viewCone.viewAngle / 2, false);
        Vector3 viewAngleB = viewCone.DirectionFromAngle(viewCone.viewAngle / 2, false);

        Handles.color = Color.red;
        Handles.DrawWireArc(viewCone.transform.position, Vector3.up, Vector3.forward, 360, viewCone.viewDistance);

        // Left (negative)
        Handles.color = Color.green;
        Handles.DrawWireArc(viewCone.transform.position, Vector3.up, viewAngleA, viewCone.viewAngle /2, viewCone.viewDistance);
        
        Handles.DrawLine(viewCone.transform.position, viewCone.transform.position + viewAngleA * viewCone.viewDistance);

        // Right (right)
        Handles.color = Color.green; 
        Handles.DrawWireArc(viewCone.transform.position, Vector3.up, viewAngleB, -viewCone.viewAngle /2, viewCone.viewDistance);

        Handles.DrawLine(viewCone.transform.position, viewCone.transform.position + viewAngleB * viewCone.viewDistance);
        
        //Handles.DrawLine(viewCone.transform.position, viewCone.transform.position + viewCone.viewAngle * viewCone.viewDistance);
        //Handles.DrawLine(viewCone.transform.position, viewCone.transform.position + viewAngleB * viewCone.viewDistance);
    }
}
