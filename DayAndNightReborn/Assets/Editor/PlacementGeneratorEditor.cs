using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlacementGenerator))]
public class PlacementGeneratorEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        PlacementGenerator placementGenerator = (PlacementGenerator)target;

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate")) {
            placementGenerator.Generate();
        }

        if (GUILayout.Button("Clear")) {
            placementGenerator.Clear();
        }
        GUILayout.EndHorizontal();
    }
}