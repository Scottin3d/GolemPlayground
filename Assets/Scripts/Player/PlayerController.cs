using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public Camera Camera;

  public float PlayerSpeed = 25f;
  public float RotationSpeed = 35f;
  public float MaxSpeed = 12f;
  public float JumpHeight = 0.3f;
  public float Magnitude;
  
  PlayerBehavior playerBehavior;
  private Rigidbody rigidbody;
  private bool IsGrounded;

  private void Awake() {
    playerBehavior = GetComponent<PlayerBehavior>();
    rigidbody = GetComponent<Rigidbody>();

  }
  // Start is called before the first frame update
  void Start() {
    IsGrounded = true;
  }

  void Update() {

    // position
    Vector3 Movement = transform.position;
    if (Input.GetKey(KeyCode.W)) {
      // Movement.z += PlayerSpeed * Time.deltaTime;
      transform.position += transform.TransformDirection(Vector3.forward) * PlayerSpeed * Time.deltaTime;
    }
    if (Input.GetKey(KeyCode.S)) {
      transform.position += transform.TransformDirection(Vector3.back) * PlayerSpeed * Time.deltaTime;
    }
    if (Input.GetKey(KeyCode.A)) {
      transform.position += transform.TransformDirection(Vector3.left) * PlayerSpeed * Time.deltaTime;
    }
    if (Input.GetKey(KeyCode.D)) {
      transform.position += transform.TransformDirection(Vector3.right) * PlayerSpeed * Time.deltaTime;
    }

    Vector3 Rotation = transform.rotation.eulerAngles;
    // rotation
    if (Input.GetKey(KeyCode.Q)) {
      transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.E)) {
      transform.Rotate(Vector3.up * -RotationSpeed * Time.deltaTime);
    }

    Jump();
    Magnitude = rigidbody.velocity.magnitude;
    if (Magnitude > MaxSpeed) {
      rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, MaxSpeed);
    }
  }

  void Jump() {
    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) {
      rigidbody.AddForce(Vector3.up * JumpHeight * 1000);
      IsGrounded = false;
    }
  }

  private void OnCollisionEnter(Collision collision) {
    // hits ground after jump
    if (collision.gameObject.tag == "ground" && IsGrounded == false) {
      IsGrounded = true;
      rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 3f);
    }

    // hits another player
    if (collision.gameObject.tag == "Player") {
      playerBehavior.HitPlayer();
      StartCoroutine(Camera.GetComponent<CameraShake>().Shake(.2f, rigidbody.velocity.magnitude * 0.2f));
    }
  }
}
