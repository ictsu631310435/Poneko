using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScaleSpriteWithScreen))]
public class ScaleSpriteWithScreenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScaleSpriteWithScreen scaleSprite = (ScaleSpriteWithScreen)target;

        if (GUILayout.Button("Scale"))
        {
            scaleSprite.Scale();
        }
    }
}
