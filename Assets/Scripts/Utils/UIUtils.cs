using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIUtils
{
    public static void Slider_Register_OnValueChanged(ref Slider slider, Action action)
    {
        slider.onValueChanged.AddListener(delegate { action(); });
    }

    public static void Slider_Register_OnValueChanged(ref Slider slider, Action<float> action)
    {
        Slider temp = slider;
        slider.onValueChanged.AddListener(delegate { action(temp.value); });
    }
}
