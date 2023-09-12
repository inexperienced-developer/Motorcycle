using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Utils/Layer Mask", fileName = "settings_layerMask")]
public class SettingsLayerMask : ScriptableObject
{
    [SerializeField] private LayerMask m_groundOnly;
    public LayerMask GroundOnly => m_groundOnly;
}
