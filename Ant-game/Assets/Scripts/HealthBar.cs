//
// Following code was made by following the linked tutorial
//
// Author : Brackeys
// Channel: https://www.youtube.com/c/Brackeys
// Source : https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=997s&ab_channel=Brackeys

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health){
        slider.maxValue = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
