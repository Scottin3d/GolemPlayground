using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Controller : MonoBehaviour {
  public Camera Camera;

  public float Speed = 25f;
  public float RotationSpeed = 55f;
  public float MaxSpeed = 12f;
  public float boostSpeed = 50f;
  private bool boost;
  public float JumpHeight = 0.3f;
  public float Magnitude;

  public float moveHorizontal;
  public float moveVertical;

  private Rigidbody rigidBody;
  private PlayerBehavior playerBehavior;
  private bool IsGrounded;

  //public int PowerUpCount = 0;

  private void Start() {
    boost = false;
    IsGrounded = true;
    rigidBody = GetComponent<Rigidbody>();
    playerBehavior = GetComponent<PlayerBehavior>();
  }

  void FixedUpdate() {
    moveHorizontal = Input.GetAxis("Horizontal");
    moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    // position
    rigidBody.AddForce(Camera.transform.TransformDirection(movement) * Speed * 10 * Time.deltaTime);

    // rotation
    if (Input.GetKey(KeyCode.Q)) {
      transform.Rotate(Vector3.up * -RotationSpeed * Time.deltaTime);
      Camera.transform.RotateAround(transform.position, Vector3.up, -RotationSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.E)) {
      transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
      Camera.transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);

    }

    /*
    Boost
    */
    if (Input.GetMouseButtonDown(1)) {
      int PowerUpCount = playerBehavior.GetPowerUpCount();
      if (PowerUpCount > 0) {
        Debug.Log("BOOOST!");
        rigidBody.AddForce(Camera.transform.TransformDirection(movement) * boostSpeed * 100);
        playerBehavior.UsePowerUp();
        boost = true;
      }
    }
    if (Input.GetMouseButtonUp(1)) {
      boost = false;
    }

    //txt.text = PowerUpCount.ToString();
  }

  private void Update() {
    // jump
    if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) {
      Jump();
    }
    Magnitude = rigidBody.velocity.magnitude;
    if (!boost && Magnitude > MaxSpeed) {
      rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxSpeed);
    } else if (boost && Magnitude > MaxSpeed * 2) {
      rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, MaxSpeed * 2);
    }
  }

  void Jump() {
    rigidBody.AddForce(Vector3.up * JumpHeight * 1000);
    IsGrounded = false;
  }

  private void OnCollisionEnter(Collision collision) {
    // hits ground after jump
    if (collision.gameObject.tag == "ground" && IsGrounded == false) {
      IsGrounded = true;
      rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, 3f);
    }

    // hits another player
    if (collision.gameObject.tag == "Player") {
      playerBehavior.HitPlayer();
      // if hit another player while boost, double damage
      if (boost) {
        playerBehavior.HitPlayer();
      }
      CameraShaker.Instance.ShakeOnce(4f * rigidBody.velocity.magnitude / 2, 4f, .1f, 1f * rigidBody.velocity.magnitude / 4);
    }
  }
}
