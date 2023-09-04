using System;
using UnityEngine;

[Serializable]
public class PlayerFuel
{
    public float FuelLevel { get; private set; } = 100;

    public void SetFuel(float fuel)
    {
        FuelLevel = fuel;
        FuelLevel = Mathf.Clamp(FuelLevel, 0, 100);
        EventsGame.OnUpdateFuelLevelUI(FuelLevel);
    }
    /// <summary>
    /// Used to add or remove fuel
    /// </summary>
    /// <param name="fuel"></param>
    public void ChangeFuel(float fuel)
    {
        if (FuelLevel == 0) return;
        FuelLevel += fuel;
        FuelLevel = Mathf.Clamp(FuelLevel, 0, 100);
        if(FuelLevel == 0) EventsGame.OnOutOfFuel();
        EventsGame.OnUpdateFuelLevelUI(FuelLevel);
    }
}
