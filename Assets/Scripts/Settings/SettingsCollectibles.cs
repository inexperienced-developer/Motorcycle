using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Collectibles", fileName = "settings_collectibles")]
public class SettingsCollectibles : ScriptableObject
{
    [Header("General Settings")]
    [SerializeField] private Vector2 m_xSpawnBounds;
    public Vector2 XSpawnBounds => m_xSpawnBounds;

    [Header("Fuel Can Settings")]
    [SerializeField] private FuelCan m_fuelCanPrefab;
    public FuelCan FuelCanPrefab => m_fuelCanPrefab;
    [SerializeField] private int m_fuel_smallAmtToGain = 10;
    [SerializeField] private int m_fuel_largeAmtToGain = 50;
    public int Fuel_SmallAmtToGain => m_fuel_smallAmtToGain;
    public int Fuel_LargeAmtToGain => m_fuel_largeAmtToGain;
    [SerializeField] private Vector2 m_fuel_SpawnTime_ms = new Vector2(3000, 10000);
    public Vector2 Fuel_SpawnTime_ms => m_fuel_SpawnTime_ms;
    [SerializeField] private float m_fuel_ChanceToSpawn_percent = 75;
    public float Fuel_ChanceToSpawn_percent => m_fuel_ChanceToSpawn_percent;

    [Header("Boost Settings")]
    [SerializeField] private BoostPickup m_boostPrefab;
    public BoostPickup BoostPrefab => m_boostPrefab;
    [SerializeField] private int m_boost_AmtToGain = 20;
    public int Boost_AmtToGain => m_boost_AmtToGain;
}
