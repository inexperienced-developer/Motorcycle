using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuBtns : MonoBehaviour
{
    [SerializeField] private Button m_start;
    
    private void Awake()
    {
        m_start.onClick.RemoveAllListeners();
        m_start.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Scenes.GAME);
        });
    }
}
