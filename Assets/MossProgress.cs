using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MossProgress : MonoBehaviour {

  public Slider slider;


  public void SetMaxValue(int MaxFill) {
    slider.maxValue = MaxFill;
  }

  public void GrowProgressBar(int Fill) {

    slider.value = Fill + 1;
  }
}
