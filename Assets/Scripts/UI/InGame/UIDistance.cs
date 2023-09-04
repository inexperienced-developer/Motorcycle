using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class UIDistance : MonoBehaviour
{
    private TMP_Text m_distanceText;
    private int m_lastDistance;

    private void Awake()
    {
        EventsGame.UpdateDistance += OnUpdateDistance;
        m_distanceText = GetComponent<TMP_Text>();
        m_distanceText.SetText($"0M");
    }

    private void OnDestroy()
    {
        EventsGame.UpdateDistance -= OnUpdateDistance;
    }

    private void OnUpdateDistance(float distance)
    {
        int rounded = Mathf.FloorToInt(distance);
        if (rounded == m_lastDistance) return;
        m_lastDistance = rounded;
        string text = "";
        if (m_lastDistance < 1000)
        {
            text = $"{m_lastDistance}M";
        }
        else
        {
            float newDist = (float)m_lastDistance * 0.001f;
            string adjText = newDist.ToString("0.0");
            text = $"{adjText}KM";
        }
        m_distanceText.SetText(text);
    }
}
