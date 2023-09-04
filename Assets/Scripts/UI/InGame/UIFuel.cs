using UnityEngine;
using UnityEngine.UI;

public class UIFuel : MonoBehaviour
{
    private Slider m_slider;

    private float m_lastValue, m_newValue;
    private float m_lerp;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();
        EventsGame.UpdateFuelLevelUI += OnUpdateFuel;
    }

    private void OnDestroy()
    {
        EventsGame.UpdateFuelLevelUI -= OnUpdateFuel;
    }

    private void Update()
    {
        m_lerp += Time.deltaTime;
        m_slider.value = Mathf.Lerp(m_lastValue, m_newValue, m_lerp);
    }

    private void OnUpdateFuel(float fuel)
    {
        if(fuel == 0) m_slider.value = 0;
        m_lerp = 0;
        m_lastValue = m_slider.value;
        m_newValue = fuel;
    }
}
