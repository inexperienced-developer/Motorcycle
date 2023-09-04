using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventsPlayer
{
    public static event Action PlayerDestroyed;
    public static void OnPlayerDestroyed() => PlayerDestroyed?.Invoke();
}
