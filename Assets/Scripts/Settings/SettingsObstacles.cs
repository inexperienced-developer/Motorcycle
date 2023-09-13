using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Obstacles", fileName = "settings_obstacles")]
public class SettingsObstacles : ScriptableObject
{
    [SerializeField] private Ramp m_rampPrefab;
    public Ramp RampPrefab => m_rampPrefab;
}
