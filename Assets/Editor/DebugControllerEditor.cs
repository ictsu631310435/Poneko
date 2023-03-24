using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DebugController))]
public class DebugControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DebugController debug = (DebugController)target;

        if (GUILayout.Button("Toggle Debug"))
        {
            debug.ToggleDebug();
        }
    }
}
