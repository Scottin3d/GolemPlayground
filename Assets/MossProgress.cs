using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MossProgress : MonoBehaviour {

  public Slider slider;


  public void SetMaxValue(int MaxFill) {
    slider.maxValue = MaxFill;
    Debug.Log("Max Progress Set to: " + MaxFill);

  }

  

  // public void GrowProgressBar(int Fill) {
  public void AddScore() {
    // legacy
    // slider.value = Fill;
    slider.value++;

    Debug.Log("Score increased.");
  }

  public void SubtractScore() {
    // legacy
    // slider.value = Fill;
    slider.value--;

    Debug.Log("Score Decreased.");
  }


}
