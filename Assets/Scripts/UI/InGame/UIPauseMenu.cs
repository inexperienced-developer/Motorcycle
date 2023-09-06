using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private Slider m_musicSlider;
    [SerializeField] private Slider m_sfxSlider;

    private void Awake()
    {
        EventsGame.Pause += OnPause;

        UIUtils.Slider_Register_OnValueChanged(ref m_musicSlider, ChangeMusic);
        UIUtils.Slider_Register_OnValueChanged(ref m_sfxSlider, ChangeSFX);

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventsGame.Pause -= OnPause;
    }

    private void OnPause(bool pause)
    {
        gameObject.SetActive(pause);
    }

    public void Pause()
    {
        // Pause is the opposite of this game object since this game object is toggled on pause
        bool shouldPause = !gameObject.activeSelf;
        EventsGame.OnPause(shouldPause);
    }

    public void Quit()
    {
        EventsGame.OnQuit();
    }

    public void ChangeMusic(float val)
    {
        EventsAudio.OnChangeAudioVolume(Mixer.MUSIC_VOLUME, val);
    }
    public void ChangeSFX(float val)
    {
        EventsAudio.OnChangeAudioVolume(Mixer.CAR_VOLUME, val);
    }
}
