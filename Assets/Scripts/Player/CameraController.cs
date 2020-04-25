using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
  public float RotationSpeed = 55f;
  public GameObject Player;
  private Vector3 Offset;
  public float rotateHorizontal;
  public float rotateVertical;

  void Start() {
    Offset = transform.position - Player.transform.position;
  }

  // Update is called once per frame
  void Update() {
    rotateHorizontal = Input.GetAxis("HorizontalTurn");
    rotateVertical = Input.GetAxis("VerticalTurn");
    Vector3 rotation = new Vector3(rotateVertical, rotateHorizontal, 0);
    transform.Rotate(rotation);

    transform.position = Player.transform.position + Offset;
  }
}
