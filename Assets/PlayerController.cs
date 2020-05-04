using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public float moveSpeed = 15f;
  private Vector3 moveDirection;
  // Update is called once per frame
  void Update() {
    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
  
  }

  private void FixedUpdate() {
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.smoothDeltaTime);
  }
}
