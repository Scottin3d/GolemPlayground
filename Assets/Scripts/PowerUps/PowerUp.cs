using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

  private void OnTriggerEnter(Collider other) {
    PlayerBehavior playerBehavior = other.GetComponent<PlayerBehavior>();
    if (playerBehavior != null) {
      PowerUpCollide(playerBehavior);
    }
  }

  private void PowerUpCollide(PlayerBehavior playerBehavior) {
    playerBehavior.AddPowerUp();
  }
}
