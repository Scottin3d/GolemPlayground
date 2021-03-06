﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

/*
 This script generates the player geometry
 */
public class GollemScript : MonoBehaviour {

  public GameObject BaseModel;
  public GameObject GolPrefab;

  [Range(0.1f, 1.0f)]
  public float ObjectSize = 0.7f;

  public Material Texture;
  public List<GameObject> GolemPieces;

  private int ObjCount = 0;

  Material golemMaterial;
  void Awake() {
    //golemMaterial = Resources.Load("Materials/Gollem.mat", typeof(Material)) as Material;
    GolemPieces = new List<GameObject>();
    GenerateMesh();
    ObjCount = GolemPieces.Count;
    Debug.Log(ObjCount + " Pieces created");
  }

  public void GenerateMesh() {
    // get mesh
    var MeshFilter = BaseModel.GetComponent<MeshFilter>();
    // get verticies to spawn instance meshes
    Vector3[] vertices1 = MeshFilter.sharedMesh.vertices;


    // spawn isntance meshes
    for (int i = 0; i < vertices1.Length; i++) {
      // set a random rotation
      Vector3 Rotation = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

      // add player position
      Vector3 Position = transform.position + vertices1[i];

      var GolInstance = Instantiate(GolPrefab, Position, Quaternion.identity);
      GolInstance.transform.parent = transform;
      GolInstance.transform.localScale = new Vector3(ObjectSize, ObjectSize, ObjectSize);
      GolInstance.transform.Rotate(Rotation);

      // add rock material to instance
      GolInstance.GetComponent<MeshRenderer>().material = Texture;

      // add instance to list
      GolemPieces.Add(GolInstance);
    }
  }

  public void UpdateScaleOfObjects() {
    Vector3 Scale = new Vector3(ObjectSize, ObjectSize, ObjectSize);
    foreach (GameObject Obj in GolemPieces) {
      Obj.transform.localScale = Scale;
    }
  }

  // get the number of instances in player
  public int GetSize() {
    return ObjCount;
  }

  List<GameObject> Randomize(List<GameObject> List) {
    Debug.Log("Starting Randomization");
    List<GameObject> RandomList = new List<GameObject>();
    bool[] Switch = new bool[List.Count];
    bool Complete = false;
    int count = 0;

    Debug.Log(List.Count + " instance objects");

    while (!Complete) {
      int Rand = Random.Range(0, ObjCount);
      Debug.Log("Trying index " + Rand);
      if (!Switch[Rand]) {
        Debug.Log("Placing in new List");

        RandomList.Add(List[Rand]);
        Switch[Rand] = true;
      } else {
        Debug.Log("Already in List");

      }
      Complete = Switch.All(x => x);
      count++;
      if (count >= 1000) {
        break;
      }
    }


    return RandomList;
  }
}
