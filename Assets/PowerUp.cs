using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
  public PlayerBehavior playerBehavior;

  private void OnTriggerEnter(Collider other) {
    PowerUpCollide();
  }

  private void PowerUpCollide() {
    playerBehavior.AddPowerUp();
  }
}
