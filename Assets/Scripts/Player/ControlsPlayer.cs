using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsPlayer : MonoBehaviour
{
    private PlayerInputActions m_actions;

    private void Awake()
    {
        m_actions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        m_actions.Enable();
    }

    private void OnDisable()
    {
        m_actions.Disable();
    }

    public Vector2 WASD => m_actions.Player.Move.ReadValue<Vector2>();

    // Mobile
    public bool TouchHeld => m_actions.Player.Touch.IsPressed();
    public bool TouchReleased => m_actions.Player.Touch.WasReleasedThisFrame();
    public Vector2 TouchPos => m_actions.Player.TouchPos.ReadValue<Vector2>();
}
