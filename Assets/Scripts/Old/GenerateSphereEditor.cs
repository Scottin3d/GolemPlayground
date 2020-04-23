using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CreateSphere))]
public class GeneratePlanetEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CreateSphere myScript = (CreateSphere)target;
        if (GUILayout.Button("Create Planet"))
        {
            myScript.CreatePlanet();
        }
    }
}