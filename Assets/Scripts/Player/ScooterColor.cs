using System;
using UnityEngine;

public class ScooterColor : MonoBehaviour
{
    [SerializeField] private Material m_adjustableColor;
    [SerializeField] private Renderer[] m_adjustedRenderers;

    private void Awake()
    {
        EventsGame.ChangeScooterColor += OnChangeScooterColor;
    }

    private void Start()
    {
        OnChangeScooterColor(GameManager.SelectedColor);
    }

    private void OnDestroy()
    {
        EventsGame.ChangeScooterColor -= OnChangeScooterColor;
    }

    private void OnChangeScooterColor(E_ScooterColors color)
    {
        Debug.Log($"Change color: {color}");
        Vector2 colorVector = Settings.ScooterColors.Colors[color];
        m_adjustableColor.SetFloat("_OffsetX", colorVector.x);
        m_adjustableColor.SetFloat("_OffsetY", colorVector.y);
        foreach(var renderer in m_adjustedRenderers)
        {
            Material[] mats = renderer.materials;
            mats[0] = m_adjustableColor;
            renderer.materials = mats;
        }
    }
}
