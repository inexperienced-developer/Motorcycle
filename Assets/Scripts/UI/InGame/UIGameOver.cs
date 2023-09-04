using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private Button m_retry;

    private void Awake()
    {
        EventsGame.GameOver += OnGameOver;
        m_retry.onClick.RemoveAllListeners();
        m_retry.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Scenes.GAME);
        });
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventsGame.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        gameObject.SetActive(true);
    }
}
