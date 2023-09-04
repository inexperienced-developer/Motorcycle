using System.Collections.Generic;
using UnityEngine;

public enum E_ScooterColors
{
    GREEN,
    BLUE_LIGHT,
    BLUE_DARK,
    PINK,
    WHITE,
    YELLOW,
    KILL_BILL
}

[CreateAssetMenu(menuName = "Settings/Scooter Colors", fileName = "settings_scooterColors")]
public class SettingsScooterColor : ScriptableObject
{
    [SerializeField] private Vector2 m_limeGreen = Vector2.zero;
    [SerializeField] private Vector2 m_lightBlue = new Vector2(0.36f, 0.36f);
    [SerializeField] private Vector2 m_darkBlue = new Vector2(0.56f, 0.36f);
    [SerializeField] private Vector2 m_pink = new Vector2(0.4f, 0.5f);
    [SerializeField] private Vector2 m_white = new Vector2(0.75f, 0.75f);
    [SerializeField] private Vector2 m_yellow = new Vector2(0.5f, 0.75f);
    [SerializeField] private Vector2 m_killBill = new Vector2(0.1f, 0.907f);

    private Dictionary<E_ScooterColors, Vector2> m_colors;
    public Dictionary<E_ScooterColors, Vector2> Colors
    {
        get
        {
            if(m_colors == null)
            {
                m_colors = new Dictionary<E_ScooterColors, Vector2>()
                {
                    { E_ScooterColors.GREEN, m_limeGreen},
                    { E_ScooterColors.BLUE_LIGHT, m_lightBlue},
                    { E_ScooterColors.BLUE_DARK, m_darkBlue},
                    { E_ScooterColors.PINK, m_pink},
                    { E_ScooterColors.WHITE, m_white},
                    { E_ScooterColors.YELLOW, m_yellow},
                    { E_ScooterColors.KILL_BILL, m_killBill},
                };
            }
            return m_colors;
        }
    }
}
