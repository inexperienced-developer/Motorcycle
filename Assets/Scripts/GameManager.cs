using UnityEngine;

public static class GameManager
{
    public static E_ScooterColors SelectedColor { get; private set; }
    public static void SetColor(E_ScooterColors color) => SelectedColor = color;
}
