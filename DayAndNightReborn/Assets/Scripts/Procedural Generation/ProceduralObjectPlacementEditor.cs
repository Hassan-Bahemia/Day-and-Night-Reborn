using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ProceduralObjectPlacement))]
public class ProceduralObjectPlacementEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        ProceduralObjectPlacement placementGenerator = (ProceduralObjectPlacement)target;

        GUILayout.Space(5);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Generate")) {
            placementGenerator.Generate();
        }

        if (GUILayout.Button("Clear")) {
            placementGenerator.ClearPrefabs();
        }
        GUILayout.EndHorizontal();
    }
}
