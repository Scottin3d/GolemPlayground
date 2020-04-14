using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
  GollemScript GScript;
  int ObjCount = 0;
  int ObjFillIndex = 0;

  public MossProgress MP;

  public Color StartColor = Color.white;
  public Color EndColor = Color.green;

  public float FillSpeed = 0.005f;
  public float FillLevel = 0f;
  public float JumpCost = 0.2f;

  // Start is called before the first frame update
  void Start() {
    GScript = this.GetComponent<GollemScript>();
    ObjCount = GScript.GetSize();
    MP.SetMaxValue(ObjCount);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      FillLevel -= JumpCost;
      UpdateColor();
    }
    if (Input.GetKey(KeyCode.W)) {
      FillLevel += FillSpeed;
      UpdateColor();
    }
    if (Input.GetKey(KeyCode.A)) {
      FillLevel += FillSpeed;
      UpdateColor();
    }
    if (Input.GetKey(KeyCode.S)) {
      FillLevel += FillSpeed;
      UpdateColor();
    }
    if (Input.GetKey(KeyCode.D)) {
      FillLevel += FillSpeed;
      UpdateColor();
    }
    
  }

  void UpdateColor() {
    if (FillLevel >= 1.0f) {
      // temp to prevent nullreference
      if (ObjFillIndex < ObjCount) {
        Debug.Log(ObjFillIndex);
        ObjFillIndex++;
      }
      FillLevel = 0f;
    }
    GScript.GolemPieces[ObjFillIndex].GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, FillLevel);
    MP.GrowProgressBar(ObjFillIndex);
  }
}
