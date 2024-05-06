using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor (typeof (PerlinNoise))]
public class EditorUI : Editor
{
    public override void OnInspectorGUI() {
        PerlinNoise genNoise = (PerlinNoise)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Generate")) {
            genNoise.UpdateNoise();
        }
    }
}
