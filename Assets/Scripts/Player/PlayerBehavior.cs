using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
  public int HitPlayerCost = 50;
  public int PlayerHitCost = 100;
  public int scorePerChunk = 100;



  private UI_API UIAPI;
  private ChangeColor changeColor;
  private GollemScript golemScript;
  private int golemPieces;
  private int PowerUpCount;
  public int PlayerScore;
  // Start is called before the first frame update
  private void Awake() {
    UIAPI = GetComponent<UI_API>();
    changeColor = GetComponent<ChangeColor>();
    golemScript = GetComponent<GollemScript>();
    
    PowerUpCount = 0;
    PlayerScore = 0;

  }

  private void Start() {
    golemPieces = golemScript.GetSize();
    changeColor.SetScorePerChunk(scorePerChunk);
    UIAPI.SetMaxScore(scorePerChunk * golemPieces);
    Debug.Log("Max Progress Set to: " + scorePerChunk * golemPieces);
  }

  private void Update() {
    // update color of player
    changeColor.UpdateColor(PlayerScore);
  }

  public void SetMaxScore(int maxScore) {
    UIAPI.SetMaxScore(maxScore);
  }

  public void UsePowerUp() {
    PowerUpCount--;
    UIAPI.SetPowerUp(PowerUpCount);
  }

  public void AddPowerUp() {
    PowerUpCount++;
    UIAPI.SetPowerUp(PowerUpCount);
  }

  public int GetPowerUpCount() {
    return PowerUpCount;
  }

  public void AddScore() {
    PlayerScore++;
    UIAPI.UpdateScore(PlayerScore);
  }

  public void HitPlayer() {
    PlayerScore -= HitPlayerCost;
    UIAPI.UpdateScore(PlayerScore);
  }

  public void HitByPlayer() {
    PlayerScore -= PlayerHitCost;
    UIAPI.UpdateScore(PlayerScore);
  }
}
