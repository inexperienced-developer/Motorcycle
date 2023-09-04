using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(Scenes.GAME);
    }
}
