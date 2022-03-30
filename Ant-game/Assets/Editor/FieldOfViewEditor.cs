using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor{
  
    void OnSceneGUI(){
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirectionFromAngle(-fow.viewAngle/2 +90, false);
        Vector3 viewAngleB = fow.DirectionFromAngle(fow.viewAngle/2 +90, false);

        Vector3 viewAngle2A = fow.DirectionFromAngle(-fow.viewAngle/6 +90, false);
        Vector3 viewAngle2B = fow.DirectionFromAngle(fow.viewAngle/6 +90, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngle2A * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngle2B * fow.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.visibleTargetsMid){
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
        Handles.color = Color.blue;
        foreach (Transform visibleTarget in fow.visibleTargetsLeft){
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }
        Handles.color = Color.green;
        foreach (Transform visibleTarget in fow.visibleTargetsRight){
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }

    }

}

// Sourced from https://www.youtube.com/watch?v=rQG9aUWarwE&ab_channel=SebastianLague with additions to serve our purpose.
