using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public GameObject Player;

  [Range(35f,75f)]
  public float RotationSpeed = 50f;

  private Vector3 Offset;
  // Start is called before the first frame update
  void Start() {
    Offset = transform.position - Player.transform.position;
  }


  // Update is called once per frame
  void Update() {
    if (Input.GetKey(KeyCode.Q)) {
      transform.RotateAround(Player.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.E)) {
      transform.RotateAround(Player.transform.position, Vector3.up, -RotationSpeed * Time.deltaTime);
    }

 

    transform.position = Player.transform.position + Offset;
  }
}
