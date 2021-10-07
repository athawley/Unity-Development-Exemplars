using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FieldOfViewVisionCone))]
public class FieldOfViewEditor : Editor
{

    void OnSceneGUI()
    {
        FieldOfViewVisionCone fovViewCone = (FieldOfViewVisionCone)target;
        Handles.color = Color.red; 
        Vector3 viewAngleA = fovViewCone.DirectionFromAngle(-fovViewCone.viewAngle / 2, false);
        Vector3 viewAngleB = fovViewCone.DirectionFromAngle(fovViewCone.viewAngle / 2, false);

        Handles.color = Color.red;
        Handles.DrawWireArc(fovViewCone.transform.position, Vector3.up, Vector3.forward, 360, fovViewCone.viewDistance);

        // Left (negative)
        Handles.color = Color.green;
        Handles.DrawWireArc(fovViewCone.transform.position, Vector3.up, viewAngleA, fovViewCone.viewAngle /2, fovViewCone.viewDistance);
        
        Handles.DrawLine(fovViewCone.transform.position, fovViewCone.transform.position + viewAngleA * fovViewCone.viewDistance);

        // Right (right)
        Handles.color = Color.green; 
        Handles.DrawWireArc(fovViewCone.transform.position, Vector3.up, viewAngleB, -fovViewCone.viewAngle /2, fovViewCone.viewDistance);

        Handles.DrawLine(fovViewCone.transform.position, fovViewCone.transform.position + viewAngleB * fovViewCone.viewDistance);
        
        Handles.color = Color.yellow;
        foreach(Transform visibleTarget in fovViewCone.visibleTargets) {
            Handles.DrawLine(fovViewCone.transform.position, visibleTarget.position);
        }
    }
}
