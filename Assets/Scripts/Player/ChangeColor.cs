using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
  private GollemScript GScript;
  int ObjCount = 0;
  int ObjFillIndex = 0;



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
    GScript = this.GetComponent<GollemScript>();
  }

  public void SetScorePerChunk(int scorePC) {
    scorePerChunk = scorePC;
  }

  public void UpdateColor(int playerScore) {
    fillIndex = playerScore / scorePerChunk;
    fillLevel = playerScore % scorePerChunk;
    GScript.GolemPieces[fillIndex].GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, fillLevel);
  }
}
