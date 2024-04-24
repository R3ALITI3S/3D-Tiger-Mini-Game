using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // see this

public class HealthBar : MonoBehaviour
{
    public Slider slider; // ui value, 
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; // set to max 100 in unity
        slider.value = health; // where the slider is

        fill.color = gradient.Evaluate(1f); // sets the gradiet on the picture to 1 as the gradient scale is from 0 to 1. (it is in f as to get decimals.)
    }

    // Update is called once per frame
    public void SetCurrentHealth(int health) 
    {
        slider.value = health; // where the slider is
        fill.color = gradient.Evaluate(slider.normalizedValue); // sets the gradiet on the picture to the value corresponding to the health. The normalized value is a scale from 0 to 100%.
    }
}
