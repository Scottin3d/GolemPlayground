using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
  public IEnumerator Shake(float duration, float magnitude) {
    Vector3 Origin = transform.localPosition;

    float elapse = 0f;

    while (elapse < duration) {
      float X = Random.Range(-1f, 1f) * magnitude;
      float Y = Random.Range(-1f, 1f) * magnitude;

      transform.localPosition = new Vector3(X, Y, Origin.z);

      elapse += Time.deltaTime;
      yield return null;
    }

    transform.localPosition = Origin;

  }
}
