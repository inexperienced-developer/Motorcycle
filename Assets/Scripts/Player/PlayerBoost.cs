using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerBoost : MonoBehaviour
{
    private float m_boostLevel;
    public float BoostLevel
    {
        get => m_boostLevel;
        private set
        {
            m_boostLevel = value;
            EventsPlayer.OnBoostChangedUI(value);
        }
    }

    private bool m_enabled;

    private void Awake()
    {
        EventsPlayer.UseBoostUI += OnUseBoost;
        EventsPlayer.PickupBoost += OnPickupBoost;
    }

    private void OnDestroy()
    {
        EventsPlayer.UseBoostUI -= OnUseBoost;
        EventsPlayer.PickupBoost -= OnPickupBoost;
    }

    private void OnPickupBoost()
    {
        ChangeBoost(Settings.Collectibles.Boost_AmtToGain);
    }

    private void OnUseBoost(bool val)
    {
        Debug.Log($"ON USE BOOST: {val}");
        m_enabled = val;
        EventsPlayer.OnUseBoost(val);
    }

    private void Start()
    {
        BoostLevel = Settings.Player.DefaultStartBoost;
        m_enabled = false;
    }

    private void Update()
    {
        if (m_enabled)
        {
            if (BoostLevel <= 0)
            {
                m_enabled = false;
                EventsPlayer.OnUseBoost(false);
            }
            Boost();
        }
    }

    public void Boost()
    {
        ChangeBoost(-Settings.Player.UseBoostRate * Time.deltaTime);
    }

    public void ChangeBoost(float boost)
    {
        BoostLevel = Mathf.Clamp(BoostLevel + boost, 0, Settings.Player.DefaultStartBoost);
    }
}
