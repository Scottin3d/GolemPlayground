using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_API : MonoBehaviour {
  Canvas UI;
  // power up text box
  Text txt;

  // progress bar
  MossProgress MP;

  private void Start() {
    UI = GameObject.Find("Canvas").GetComponent<Canvas>();
    txt = UI.transform.Find("PowerUpCounter").GetComponent<Text>();
    MP = UI.transform.Find("ProgressBar").GetComponent<MossProgress>();
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
