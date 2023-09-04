using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControllerMobile : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform m_rectTransform;
    private Vector2 m_originalPos;
    private Vector2 m_limits;
    private bool m_shouldReturn;

    [SerializeField] private float m_limit = 200;
    [SerializeField] private float m_lerpSpeed = 12;

    private float m_input; // This stores the -1 to 1 value

    private void Awake()
    {
        EventsMobile.ReleaseTouch += OnReleaseTouch;
    }

    private void OnDestroy()
    {
        EventsMobile.ReleaseTouch -= OnReleaseTouch;
    }

    private void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_originalPos = m_rectTransform.anchoredPosition;

        // Let's say the ball is contained within a panel that is 200 units wide.
        // The boundaries would then be originalPosition.x +/- 100.
        m_limits.x = m_originalPos.x - m_limit;
        m_limits.y = m_originalPos.x + m_limit;
    }

    private void Update()
    {
        // Lerp position back to the center if shouldReturn is true
        //if (m_shouldReturn)
        //{
        //    m_rectTransform.anchoredPosition = Vector3.Lerp(m_rectTransform.anchoredPosition, m_originalPos, Time.deltaTime * m_lerpSpeed);
        //    if (Vector3.Distance(transform.position, m_originalPos) < 0.1f)
        //    {
        //        m_rectTransform.anchoredPosition = m_originalPos;  // Snap to center
        //        m_shouldReturn = false;  // Reset the flag
        //    }
        //}
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Start dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_rectTransform.parent as RectTransform, eventData.position, eventData.pressEventCamera, out dragPosition);

        dragPosition.x = Mathf.Clamp(dragPosition.x, m_limits.x, m_limits.y);
        m_rectTransform.anchoredPosition = new Vector2(dragPosition.x, m_originalPos.y);

        // Translate position to input value (-1 to 1)
        m_input = Mathf.InverseLerp(m_limits.x, m_limits.y, dragPosition.x) * 2f - 1f;
        EventsMobile.OnInput(m_input);
    }

    private void OnReleaseTouch()
    {
        Debug.Log("Released");
        m_rectTransform.anchoredPosition = m_originalPos;  // Snap to center
        EventsMobile.OnInput(0);
        m_shouldReturn = true;
    }
}
