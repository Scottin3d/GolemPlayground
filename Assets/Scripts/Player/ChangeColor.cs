using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
  private GollemScript GScript;
  int ObjCount = 0;
  int ObjFillIndex = 0;

  private UI_API UIAPI;
  // public MossProgress MP;

  public Color StartColor = Color.white;
  public Color EndColor = Color.green;

  public float FillSpeed = 0.005f;
  public float FillLevel = 0f;
  public float JumpCost = 0.2f;
  public int PlayerHitPenalty = 1;


  private int scorePerChunk = 0;
  int fillLevel = 0;
  int fillIndex;
  // Start is called before the first frame update
  void Start() {
    UIAPI = this.GetComponent<UI_API>();
    GScript = this.GetComponent<GollemScript>();
    ObjCount = GScript.GetSize();
    Debug.Log(ObjCount);

    //UIAPI.SetMaxScore(ObjCount);
    // MP.SetMaxValue(ObjCount);
  }

  // Update is called once per frame
  void Update() {
    /*
    if (Input.GetKeyDown(KeyCode.Space)) {
      FillLevel -= JumpCost;
      UpdateColor();
    }
    if (Input.GetKey(KeyCode.W)) {
      FillLevel += FillSpeed;
      UpdateColor();
    }
    */
  }

  public void SetScorePerChunk(int scorePC) {
    scorePerChunk = scorePC;
  }

  public void UpdateColor(int playerScore) {
    fillIndex = playerScore / scorePerChunk;
    fillLevel = playerScore % scorePerChunk;
    GScript.GolemPieces[fillIndex].GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, fillLevel);

    /*

    if (FillLevel >= 1.0f) {
      // temp to prevent nullreference
      if (ObjFillIndex < ObjCount - 1) {
        Debug.Log(ObjFillIndex);
        ObjFillIndex++;
        UIAPI.AddScore();
      } else {
        ObjFillIndex = ObjCount - 1;
        Debug.Log("Player won!");
        return;
      }
      FillLevel = 0f;
    }
    GScript.GolemPieces[ObjFillIndex].GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, FillLevel);
    
    //MP.GrowProgressBar(ObjFillIndex + 1);
    */
  }

  public void HitByPlayer() {
    Debug.Log("Player Hit!");
    int NewFillIndex = ObjFillIndex - PlayerHitPenalty;
    Debug.Log(NewFillIndex);

    while (ObjFillIndex > NewFillIndex && ObjFillIndex >= 0) {
      GScript.GolemPieces[ObjFillIndex].GetComponent<Renderer>().material.color = StartColor;
      ObjFillIndex--;
      UIAPI.SubtractScore();

      //MP.GrowProgressBar(ObjFillIndex + 1);
    }

    FillLevel = 0f;
  }
}
