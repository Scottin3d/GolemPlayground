using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(GollemScript))]
public class GolemScriptEditor : Editor {
  public override void OnInspectorGUI() {
    DrawDefaultInspector();

    GollemScript myScript = (GollemScript)target;
    if (GUILayout.Button("Create Player")) {
      myScript.GenerateMesh();
    }

    if (GUILayout.Button("Update Scale")) {
      myScript.UpdateScaleOfObjects();
    }
  }
}