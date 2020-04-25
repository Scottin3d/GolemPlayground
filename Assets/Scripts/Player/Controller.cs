using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Controller : MonoBehaviour {
  public Camera Camera;

  private float Speed = 55f;
  private float RotationSpeed = 55f;
  private float MaxSpeed = 12f;
  private float boostSpeed = 50f;
  private bool boost;
  private float JumpHeight = 0.3f;
  private float Magnitude;

  private float moveHorizontal;
  private float moveVertical;

  private float rotateHorizontal;
  private float rotateVertical;

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

    rotateHorizontal = Input.GetAxis("HorizontalTurn");
    rotateVertical = Input.GetAxis("VerticalTurn");
    Vector3 rotation = new Vector3(rotateHorizontal, rotateVertical, 0);
    

    transform.Rotate(rotation);



    // rotation
    if (Input.GetKey(KeyCode.Q)) {
      transform.Rotate(Vector3.up * -RotationSpeed * Time.deltaTime);
      Camera.transform.RotateAround(transform.position, Vector3.up, -RotationSpeed * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.E)) {
      transform.Rotate(Vector3.up * rotateHorizontal * Time.deltaTime);
      Camera.transform.RotateAround(transform.position, Vector3.up, rotateHorizontal * Time.deltaTime);

    }

    /*
    Boost
    */
    if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.JoystickButton5)) {
      int PowerUpCount = playerBehavior.GetPowerUpCount();
      if (PowerUpCount > 0) {
        Debug.Log("BOOOST!");
        rigidBody.AddForce(Camera.transform.TransformDirection(movement) * boostSpeed * 100);
        playerBehavior.UsePowerUp();
        boost = true;
      }
    }
    if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.JoystickButton5)) {
      boost = false;
    }
  }

  private void Update() {
    // jump
    if (Input.GetKeyDown(KeyCode.JoystickButton0) && IsGrounded) {
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
