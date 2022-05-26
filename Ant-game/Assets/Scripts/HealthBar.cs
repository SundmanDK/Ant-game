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
    // Source https://discord.com/channels/760817916047261746/938782013807280129/979331307127599135
}
