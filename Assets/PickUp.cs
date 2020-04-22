using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

  public Text UIText;
  public int PowerUpCount = 0;

  private void Start() {

  }

  private void Update() {
    // powerup
    if (UIText != null) {
      UIText.text = PowerUpCount.ToString();
    }
  }
}
