using InexperiencedDeveloper.Core;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMono : Singleton<GameManagerMono>
{
    protected override void Awake()
    {
        EventsGame.Pause += OnPause;
        EventsGame.Quit += OnQuit;
        SceneManager.sceneLoaded += OnSceneLoaded;
        base.Awake();
    }

    protected override void OnDestroy()
    {
        EventsGame.Pause -= OnPause;
        EventsGame.Quit -= OnQuit;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        base.OnDestroy();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnPause(false);
    }

    private void OnPause(bool pause)
    {
        float timeScale = pause ? 0 : 1f;
        Time.timeScale = timeScale;
    }

    private void OnQuit()
    {
        SceneManager.LoadScene(Scenes.MENU);
    }
}
