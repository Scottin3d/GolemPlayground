using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

  
  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "PowerUpActive") {
      Debug.Log("Power Up Picked Up!");
    }
  }
  

}
