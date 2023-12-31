using InexperiencedDeveloper.Core;
using InexperiencedDeveloper.Extensions;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-999)]
public class PlayerSingleton : Singleton<PlayerSingleton>
{
    [SerializeField] private GameObject m_bikeGfx;
    [SerializeField] private GameObject m_explosionGfx;

    private Rigidbody m_rb;
    public Rigidbody Rb
    {
        get
        {
            if(m_rb == null)
                m_rb = GetComponent<Rigidbody>();
            return m_rb;
        }
    }
    private ControlsPlayer m_input;
    public ControlsPlayer Input
    {
        get
        {
            if (m_input == null)
                m_input = GetComponent<ControlsPlayer>();
            return m_input;
        }
    }
    private Collider[] m_cols;

    private bool m_isDestroyed = false;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        m_cols = GetComponentsInChildren<Collider>(true);
    }

    protected override void OnDestroy()
    {
        SpawnManager.PlayerSpawned = false;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        base.OnDestroy();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != Scenes.GAME) return;
        Init();
    }

    private void Init()
    {
        m_isDestroyed = false;
        m_bikeGfx.SetActive(true);
        m_explosionGfx.SetActive(false);
        foreach (var col in m_cols)
            col.enabled = true;
        Rb.isKinematic = false;
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Q)) OnCrash();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(m_isDestroyed) return;
        if (collision.collider.CompareTag(Tags.GROUND)) return;
        if (collision.collider.CompareTag(Tags.WHEELS)) return;
        if(collision.collider.material.name.Split(' ')[0] == "Sand")
        {
            EventsGame.OnHitSand();
            return;
        }
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.SafeAddForce(collision.impulse * 10, ForceMode.Impulse);
        }
        OnCrash();
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckCollectible(other);
    }

    private void CheckCollectible(Collider other)
    {
        ICollectible collectible = other.gameObject.GetComponent<ICollectible>();
        if(collectible == null) return;
        collectible.Collect();
    }

    private void OnCrash()
    {
        m_isDestroyed = true;
        m_bikeGfx.SetActive(false);
        m_explosionGfx.SetActive(true);
        foreach (var col in m_cols)
            col.enabled = false;
        Rb.isKinematic = true;
        EventsGame.OnCrash();
    }
}
