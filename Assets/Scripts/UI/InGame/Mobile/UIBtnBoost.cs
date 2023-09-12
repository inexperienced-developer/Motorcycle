using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIBtnBoost : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image m_img;

    private void Awake()
    {
        EventsPlayer.BoostChangedUI += OnBoostChangedUI;
    }

    private void OnDestroy()
    {
        EventsPlayer.BoostChangedUI -= OnBoostChangedUI;
    }

    private void OnBoostChangedUI(float val)
    {
        val /= 100;
        m_img.fillAmount = val;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EventsPlayer.OnUseBoostUI(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventsPlayer.OnUseBoostUI(false);
    }
}
