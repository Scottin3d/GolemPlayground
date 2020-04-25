using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animate : MonoBehaviour {
  public float RotationSpeed = 45f;
  public float BounceSpeed = 4f;
  [Range(0.1f, 1.0f)]
  public float BounceHeight = 0.15f;
  public AnimationCurve Curve;

  public int PowerUpRespawnTime = 5;
  public AudioClip audioClip;

  private float YOffset;
  MeshRenderer MR;
  private bool Active = true;
  // Start is called before the first frame update
  void Start() {
    YOffset = transform.position.y;
    MR = GetComponent<MeshRenderer>();
  }

  void Update() {
    Bounce();
    Rotate();
  }

  void Rotate() {
    // rotating
    transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
  }

  void Bounce() {
    // flaoting
    float X = transform.position.x;
    float Y = Mathf.Sin(Time.time * BounceSpeed) * BounceHeight + YOffset;
    float Z = transform.position.z;
    transform.position = new Vector3(X, Y, Z);
  }

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      bool collect = other.gameObject.GetComponent<PlayerBehavior>().CanCollect();
      if (Active && collect) {
        MR.enabled = false;
        Active = false;
        StartCoroutine(Dissappear());

      }

    }

  }

  IEnumerator Dissappear() {
    yield return new WaitForSeconds(PowerUpRespawnTime);
    MR.enabled = true;
    Active = true;
  }
}
