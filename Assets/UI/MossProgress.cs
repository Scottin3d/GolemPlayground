using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MossProgress : MonoBehaviour {

  public Slider slider;


  public void SetMaxValue(int MaxFill) {
    slider.maxValue = MaxFill;

  }

  public void UpdateScore(int score) {
    slider.value = score;
  }


}
