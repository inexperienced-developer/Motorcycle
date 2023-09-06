using InexperiencedDeveloper.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerMono : Singleton<AudioManagerMono>
{
    [SerializeField] private AudioMixer m_mixer;

    private float m_sfxVolume;

    protected override void Awake()
    {
        EventsGame.Pause += OnPause;

        EventsAudio.ChangeAudioVolume += OnChangeAudioVolume;

        base.Awake();
    }

    protected override void OnDestroy()
    {
        EventsGame.Pause -= OnPause;

        EventsAudio.ChangeAudioVolume -= OnChangeAudioVolume;

        base.OnDestroy();
    }

    private void OnChangeAudioVolume(string key, float volume)
    {
        if(!m_mixer.GetFloat(key, out float current))
        {
            Debug.LogError($"Audio parameter doesn't exist: {key}");
            return;
        }
        m_mixer.SetFloat(key, volume);
    }

    private void OnPause(bool pause)
    {
        // TODO: AudioSettings object to set volume defaults
        AudioMixerGroup[] groups = m_mixer.FindMatchingGroups(Mixer.CAR_SOUNDS);
        foreach(var group in groups)
        {
            bool exists = group.audioMixer.GetFloat(Mixer.CAR_VOLUME, out float carVol);
            m_sfxVolume = pause ? m_sfxVolume : carVol;
            float vol = pause ? -80f : m_sfxVolume;
            if (exists)
            {
                group.audioMixer.SetFloat(Mixer.CAR_VOLUME, vol);
                break;
            }
        }
    }
}
