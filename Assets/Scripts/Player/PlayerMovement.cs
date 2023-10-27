using InexperiencedDeveloper.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private PlayerSingleton m_player;
    private PlayerFuel m_playerFuel;
    private bool m_dead;
    private float m_fuelTimer;
    private float m_currentLean;
    private float m_horizontal;
    private float m_totalDistance = 0;
    private int mNearMissPoints = 0;

    private void Start()
    {
        m_player = PlayerSingleton.Instance;
        Init();
        EventsGame.Crash += OnCrash;
        EventsGame.HitSand += OnHitSand;
        EventsGame.UpdateFuelLevel += OnUpdateFuelLevel;
        EventsGame.OutOfFuel += OnOutOfFuel;
        SceneManager.sceneLoaded += OnSceneLoaded;
#if UNITY_IOS || UNITY_ANDROID
        EventsMobile.Input += OnInput;
#endif
    }

    private void OnDestroy()
    {
        EventsGame.Crash -= OnCrash;
        EventsGame.HitSand -= OnHitSand;
        EventsGame.UpdateFuelLevel -= OnUpdateFuelLevel;
        EventsGame.OutOfFuel -= OnOutOfFuel;
        SceneManager.sceneLoaded -= OnSceneLoaded;
#if UNITY_IOS || UNITY_ANDROID
        EventsMobile.Input -= OnInput;
#endif
        EventsPlayer.OnPlayerDestroyed();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex != Scenes.GAME) return;
        Init();
    }

    private void Init()
    {
        m_player.Rb.drag = 0.1f;
        m_dead = false;
        m_playerFuel = new PlayerFuel();
        m_playerFuel.SetFuel(100);
        enabled = true;
        m_totalDistance = 0;
        UpdateDistance();
    }

    private void OnGameOver()
    {
        Init();
    }

    private void OnInput(float val)
    {
        m_horizontal = val;
    }

    private void OnUpdateFuelLevel(float fuel)
    {
        m_playerFuel.ChangeFuel(fuel);
    }

    private void OnOutOfFuel()
    {
        m_player.Rb.drag = Settings.Player.TargetDrag;
        m_dead = true;
        EventsGame.OnGameOver();
    }

    private void OnHitSand()
    {
        m_player.Rb.drag = Settings.Player.TargetDrag;
        m_dead = true;
        EventsGame.OnGameOver();
    }

    private void OnCrash()
    {
        m_player.Rb.drag = Settings.Player.TargetDrag;
        m_dead = true;
        enabled = false;
        EventsGame.OnGameOver();
    }

    private void Update()
    {
        if (m_player.Input.TouchReleased) EventsMobile.OnReleaseTouch();
#if UNITY_STANDALONE_WIN
        m_horizontal = m_player.Input.WASD.normalized.x;
#endif
        AnimateLean();
        if (m_dead) return;

        if (Input.GetKey(KeyCode.S))
        {
            m_player.Rb.drag = Mathf.Lerp(m_player.Rb.drag, Settings.Player.TargetDrag, Settings.Player.LeanSmooth / 2 * Time.deltaTime);
        }
        else
        {
            m_player.Rb.drag = 0.1f;
        }

        // Remove fuel based on velocity
        RemoveFuel();
    }

    private void RemoveFuel()
    {
        m_fuelTimer -= Time.deltaTime;
        if (m_fuelTimer > 0) return;
        m_fuelTimer = Settings.Player.FuelTickRate;
        float fuelChange = Mathf.FloorToInt(m_player.Rb.velocity.magnitude * Settings.Player.FuelTickMultiplier);
        EventsGame.OnUpdateFuelLevel(-fuelChange);
    }

    private void FixedUpdate()
    {
        if (m_dead) return;
        // To start let's just constantly move forward
        Vector3 forwardForce = transform.forward * Settings.Player.FwdSpeed;
        float forwardVelocity = Vector3.Dot(m_player.Rb.velocity, transform.forward);
        if (forwardVelocity > Settings.Player.MaxSpeed)
        {
            forwardForce = -transform.forward * Settings.Player.FwdSpeed / 2;
        }
        m_player.Rb.SafeAddForce(forwardForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        Vector3 rightForce = transform.right * m_horizontal * Settings.Player.RightSpeed;
        if (Mathf.Abs(m_player.Rb.velocity.x) > 0.1f && m_horizontal == 0)
        {
            rightForce = Vector3.zero;
            rightForce.x = -m_player.Rb.velocity.x * Settings.Player.RightSpeed / 4;
        }
        m_player.Rb.SafeAddForce(rightForce * Time.fixedDeltaTime, ForceMode.Impulse);

        UpdateDistance();
    }

    private void UpdateDistance()
    {
        // Get velocity in meters per second
        float forwardVelocity = Vector3.Dot(m_player.Rb.velocity, transform.forward);
        m_totalDistance += forwardVelocity * Time.fixedDeltaTime;
        EventsGame.OnUpdateDistance(m_totalDistance);

    }

    private void AnimateLean()
    {
        float targetLean = Settings.Player.TargetLean * -m_horizontal;
        m_currentLean = Mathf.Lerp(m_currentLean, targetLean, Settings.Player.LeanSmooth * Time.deltaTime);

        Vector3 rot = transform.localEulerAngles;
        rot.z = m_currentLean;
        transform.localRotation = Quaternion.Euler(rot);
    }

    private void UpdateScore()
    {
        mNearMissPoints =  mNearMissPoints += 20 ;
        EventsGame.OnUpdateScore(mNearMissPoints);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("NearMissBox"))
        {
            Debug.Log("Hit the Near Miss Box");
            NearMiss();
        }
    }

    private void NearMiss()
    {
     Debug.Log("NearMiss");
     EventsGame.OnNearMiss();
     UpdateScore();
    }
}
