using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);
        Handles.DrawWireArc(fow.transform.position, Vector3.up, viewAngleA, fow.viewAngle, fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        Handles.color = Color.red;
        for (int i = 0; i < fow.numberOfRays; i++)
        {
            Vector3 rayDir = fow.DirFromAngle(((fow.viewAngle / (fow.numberOfRays - 1)) * i) - fow.viewAngle/2, false);
            Handles.DrawLine(fow.transform.position, fow.transform.position + rayDir * fow.viewRadius);
        }
    }
}
