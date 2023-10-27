using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    
    private TMP_Text m_ScoreText;
    private int m_previousScore;



    private void Awake()
    {
       EventsGame.UpdateScore += OnUpdateScore;
       m_ScoreText = GetComponent<TMP_Text>();
       m_ScoreText.SetText($"");
    }

    private void OnDestroy()
    {
        EventsGame.UpdateScore -= OnUpdateScore;
    }
    
    private void OnUpdateScore(int score)
    {
        int rounded = Mathf.FloorToInt(score);
        if (rounded == m_previousScore) return;
        m_previousScore = rounded;
        string text = "";
        if (m_previousScore < 1000)
        {
            text = $"${m_previousScore}";
            Debug.Log(m_previousScore);
        }
        else
        {
            int newScore  = (int) m_previousScore * 1;
            string adjText = newScore.ToString("");
            text = $"${adjText}";
        }
        m_ScoreText.SetText(text);
    }
}
