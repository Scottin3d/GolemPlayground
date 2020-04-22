using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
  private UI_API UIAPI;

  private int PowerUpCount = 0;
  // Start is called before the first frame update
  void Start() {
    UIAPI = GetComponent<UI_API>();
  }

  // Update is called once per frame
  void Update() {

  }

  public void UsePowerUp() {
    PowerUpCount--;
    UIAPI.SetPowerUp(PowerUpCount);
    Debug.Log("PowerUp Used!");
  }

  public void AddPowerUp() {
    PowerUpCount++;
    UIAPI.SetPowerUp(PowerUpCount);
    Debug.Log("PowerUp Count: " + PowerUpCount);
  }

  public int GetPowerUpCount() {
    return PowerUpCount;
  }
}
