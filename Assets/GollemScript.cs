﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GollemScript : MonoBehaviour {

  public GameObject BaseModel;
  public GameObject GolPrefab;

  [Range(0.1f, 1.0f)]
  public float ObjectSize = 0.7f;

  public int Sides;
  public Material Texture;
  private List<GameObject> GolemPieces;
  // Start is called before the first frame update
  public Color StartColor = Color.white;
  public Color EndColor = Color.green;
  [Range(0.1f, 1.0f)]
  public float ColorSpeed = 0.1f;
  private float StartTime;

  void Start() {
    GolemPieces = new List<GameObject>();
    GenerateMesh();

    StartTime = Time.time;
  }

  private void Update() {
    ChangeColor();
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


  void ChangeColor() {
    float T = (Time.time - StartTime) * ColorSpeed;
    foreach (GameObject Obj in GolemPieces) {
      Obj.GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, T);
    }
   
  }


}