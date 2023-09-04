using System;

public static class EventsGame
{
    // Menu
    public static event Action<E_ScooterColors> ChangeScooterColor;
    public static void OnChangeSchooterColor(E_ScooterColors color) => ChangeScooterColor?.Invoke(color);

    // In Game
    public static event Action Crash;
    public static void OnCrash() => Crash?.Invoke();

    public static event Action HitSand;
    public static void OnHitSand() => HitSand?.Invoke();

    public static event Action OutOfFuel;
    public static void OnOutOfFuel() => OutOfFuel?.Invoke();

    public static event Action<float> UpdateFuelLevel;
    public static void OnUpdateFuelLevel(float fuelLevel) => UpdateFuelLevel?.Invoke(fuelLevel);

    public static event Action<float> UpdateFuelLevelUI;
    public static void OnUpdateFuelLevelUI(float fuelLevel) => UpdateFuelLevelUI?.Invoke(fuelLevel);

    public static event Action<float> UpdateDistance;
    public static void OnUpdateDistance(float distance) => UpdateDistance?.Invoke(distance);

    public static event Action GameOver;
    public static void OnGameOver() => GameOver?.Invoke();

}
