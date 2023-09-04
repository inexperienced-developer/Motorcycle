using System;
using UnityEngine;

public class EventsMobile : MonoBehaviour
{
    public static event Action<float> Input;
    public static void OnInput(float value) => Input?.Invoke(value);

    public static event Action ReleaseTouch;
    public static void OnReleaseTouch() => ReleaseTouch?.Invoke();
}
