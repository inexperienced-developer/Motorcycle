using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Player", fileName = "settings_player")]
public class SettingsPlayer : ScriptableObject
{
    [SerializeField] private GameObject m_playerPrefab;
    [SerializeField] private Vector3 m_originalPos;
    public GameObject PlayerPrefab => m_playerPrefab;
    public Vector3 OriginalPos => m_originalPos;

    [Header("Movement Settings")]
    [SerializeField] private float m_fwdSpeed = 1000;
    [SerializeField] private float m_rightSpeed = 1500;
    [SerializeField] private float m_maxSpeed = 50;
    [SerializeField] private float m_targetDrag = 100f;
    public float FwdSpeed => m_fwdSpeed;
    public float RightSpeed => m_rightSpeed;
    public float MaxSpeed => m_maxSpeed;
    public float TargetDrag => m_targetDrag;

    [Header("Lean Settings")]
    [SerializeField] private float m_targetLean = 30;
    [SerializeField] private float m_leanSmooth = 10;
    public float TargetLean => m_targetLean;
    public float LeanSmooth => m_leanSmooth;

    [Header("Fuel Settings")]
    [SerializeField] private float m_fuelTickRate = 1;
    [SerializeField] private float m_fuelTickMultiplier = 0.1f;
    public float FuelTickRate => m_fuelTickRate;
    public float FuelTickMultiplier => m_fuelTickMultiplier;

    [Header("Boost Settings")]
    [SerializeField] private float m_defaultStartBoost = 100;
    [SerializeField] private float m_useBoostRate = 5;
    public float DefaultStartBoost => m_defaultStartBoost;
    public float UseBoostRate => m_useBoostRate;
}
