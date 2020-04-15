using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Controller : MonoBehaviour
{
  public Camera Camera;

  public float Speed = 250f;
  public float RotationSpeed = 55f;
  public float MaxSpeed = 12f;
  public float JumpHeight = 0.3f;
  public float Magnitude;

  public float moveHorizontal;
  public float moveVertical;

  private ChangeColor CC;
  private Rigidbody RB;
  private bool IsGrounded;

  private void Start() {
    IsGrounded = true;
    RB = GetComponent<Rigidbody>();
    CC = GetComponent<ChangeColor>();
  }

  void FixedUpdate() {
    moveHorizontal = Input.GetAxis("Horizontal");
    moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    // position
    RB.AddForce(Camera.transform.TransformDirection(movement) * Speed * Time.deltaTime);
    
    // rotation
    if (Input.GetKey(KeyCode.Q)) {
      transform.Rotate(Vector3.up * -RotationSpeed * Time.deltaTime);
      Camera.transform.RotateAround(transform.position, Vector3.up, -RotationSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.E)) {
      transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
      Camera.transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);

    }



  }

  private void Update() {
    // jump
    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) {
      Jump();
    }
    Magnitude = RB.velocity.magnitude;
    if (Magnitude > MaxSpeed) {
      RB.velocity = Vector3.ClampMagnitude(RB.velocity, MaxSpeed);
    }

  }

  void Jump() {
    RB.AddForce(Vector3.up * JumpHeight * 1000);
    IsGrounded = false;
  }

  private void OnCollisionEnter(Collision collision) {
    // hits ground after jump
    if (collision.gameObject.tag == "ground" && IsGrounded == false) {
      IsGrounded = true;
      RB.velocity = Vector3.ClampMagnitude(RB.velocity, 3f);
    }

    // hits another player
    if (collision.gameObject.tag == "Player") {
      CC.HitByPlayer();
      CameraShaker.Instance.ShakeOnce(4f * RB.velocity.magnitude, 4f, .1f, 1f * RB.velocity.magnitude / 2);
    }


  }
}
