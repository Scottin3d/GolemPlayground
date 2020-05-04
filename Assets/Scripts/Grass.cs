using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
  private float GrassRespawnTime = 3f;
  bool Active;
  int numMeshes;
  MeshRenderer[] MR;

  private void Awake() {
    Active = true;
    numMeshes = transform.childCount;
    MR = new MeshRenderer[numMeshes];

    for (int i = 0; i < numMeshes; i++) {
      MR[i] = transform.GetChild(i).GetComponent<MeshRenderer>();
    }
   
  }

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      if (Active) {
        PlayerBehavior playerBehavior = other.GetComponent<PlayerBehavior>();
        Debug.Log("Grass");
        for (int i = 0; i < numMeshes; i++) {
          MR[i].enabled = false;
        }
        Active = false;
        StartCoroutine(Dissappear());
        //playerBehavior.AddScore();
      }

    }

  }

  IEnumerator Dissappear() {
    
    yield return new WaitForSeconds(GrassRespawnTime);
    for (int i = 0; i < numMeshes; i++) {
      MR[i].enabled = true;
    }
    Active = true;
  }
}
