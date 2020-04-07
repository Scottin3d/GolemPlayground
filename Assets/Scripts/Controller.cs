using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
  public float Speed = 250f;
  public float JumpHeight = 0.3f;
  private Rigidbody RB;
  private bool IsGrounded;

  private void Start() {
    IsGrounded = true;
    RB = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    RB.AddForce(movement * Speed * Time.deltaTime);
  }

  private void Update() {
    Jump();
    /*
    if (Input.GetKeyDown(KeyCode.Space)) {
      RB.AddForce(Vector3.up * JumpHeight * 1000);
    }
    */
  }

  void Jump() {
    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) {
      RB.AddForce(Vector3.up * JumpHeight * 1000);
      IsGrounded = false;
    }
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "ground" && IsGrounded == false) {
      IsGrounded = true;
    }
  }
}
