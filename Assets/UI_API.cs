using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_API : MonoBehaviour {

  // power up text box
  public Text txt;

  // progress bar
  public MossProgress MP;

  private void Start() {
    txt.text = "0";
  }

  public void SetMaxScore(int MaxScore) {
    MP.SetMaxValue(MaxScore);
  }

  public void AddScore() {
    MP.AddScore();
  }

  public void SubtractScore() {
    MP.SubtractScore();
  }

  public void SetPowerUp(int PowerUpCount) {
    txt.text = PowerUpCount.ToString();
  }
}
