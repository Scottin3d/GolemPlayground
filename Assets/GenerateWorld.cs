using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour {
  public GameObject prefab;
  [SerializeField]
  List<GameObject> prefabSpawned;

  [SerializeField]
  Vector3[] verticies;
  [SerializeField]
  Vector3[] normals;

  public float scale = 10f;

  [Range(0.1f, 1.0f)]
  public float offsetThreshold = 0.1f;

  // Start is called before the first frame update
  void Start() {
    prefabSpawned = new List<GameObject>();
    GeneratePlanetEditor();
    transform.localScale = new Vector3(scale, scale, scale);
  }

  // Update is called once per frame
  void Update() {

  }

  private void GeneratePlanetEditor() {
    verticies = transform.GetComponent<MeshFilter>().mesh.vertices;
    normals = transform.GetComponent<MeshFilter>().mesh.normals;



    for (int i = 0; i < verticies.Length; i++) {
      float xOffset = Random.Range(verticies[i].x - offsetThreshold, verticies[i].x + offsetThreshold);
      float yOffset = Random.Range(verticies[i].y - offsetThreshold, verticies[i].y + offsetThreshold);
      float zOffset = Random.Range(verticies[i].z - offsetThreshold, verticies[i].z + offsetThreshold);

      Vector3 offSet = new Vector3(xOffset, yOffset, zOffset);

      Vector3 Position = transform.position + verticies[i] + offSet;

      GameObject spawn = Instantiate(prefab, verticies[i], Quaternion.identity);
      spawn.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

      spawn.transform.rotation = Quaternion.FromToRotation(Vector3.up, normals[i]) * transform.rotation;
      spawn.transform.parent = this.transform;

      prefabSpawned.Add(spawn);


    }
  }
}
