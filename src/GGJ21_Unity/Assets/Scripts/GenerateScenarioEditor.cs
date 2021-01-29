using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateScenario))]
public class GenerateScenarioEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GenerateScenario generator = (GenerateScenario)target;

        if (GUILayout.Button("Generate"))
        {
            generator.Generate();
        }

        if (GUILayout.Button("Delete"))
        {
            generator.Delete();
        }
    }
}
