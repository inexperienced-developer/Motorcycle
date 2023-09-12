using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsPlayer
{
    public static event Action PlayerDestroyed;
    public static void OnPlayerDestroyed() => PlayerDestroyed?.Invoke();

    public static event Action<float> BoostChangedUI;
    public static void OnBoostChangedUI(float boost) => BoostChangedUI?.Invoke(boost);

    public static event Action<bool> UseBoostUI;
    public static void OnUseBoostUI(bool use) => UseBoostUI?.Invoke(use);

    public static event Action<bool> UseBoost;
    public static void OnUseBoost(bool use) => UseBoost?.Invoke(use);

    public static event Action PickupBoost;
    public static void OnPickupBoost() => PickupBoost?.Invoke();
}
