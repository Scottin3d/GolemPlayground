using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {
  public GravityAttractor attractor;

  Rigidbody RB;
  [SerializeField]
  private Transform myTransform;
  // Start is called before the first frame update
  void Start() {
    RB = GetComponent<Rigidbody>();
    RB.constraints = RigidbodyConstraints.FreezeRotation;
    RB.useGravity = false;
    myTransform = this.transform;
  }

  // Update is called once per frame
  void Update() {
    attractor.Attract(myTransform);
  }
}
