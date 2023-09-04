using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        EventsGame.Crash += OnCrash;
        EventsGame.HitSand += OnHitSand;
        EventsGame.OutOfFuel += OnOutOfFuel;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        EventsGame.Crash -= OnCrash;
        EventsGame.HitSand -= OnHitSand;
        EventsGame.OutOfFuel -= OnOutOfFuel;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != Scenes.GAME) return;
        m_audioSource.enabled = true;
    }

    private void OnOutOfFuel()
    {
        m_audioSource.enabled = false;
    }

    private void OnHitSand()
    {
        m_audioSource.enabled = false;
    }

    private void OnCrash()
    {
        m_audioSource.enabled = false;
    }
}
