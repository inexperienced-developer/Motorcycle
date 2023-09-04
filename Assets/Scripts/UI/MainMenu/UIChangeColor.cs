using UnityEngine;
using UnityEngine.UI;

public class UIChangeColor : MonoBehaviour
{
    [SerializeField] private GameObject m_mainPanel;

    private Button[] m_btns;

    private void Awake()
    {
        m_mainPanel.SetActive(false);
        m_btns = GetComponentsInChildren<Button>(true);
        string splitter = "color_";
        foreach(var btn in m_btns)
        {
            btn.onClick.RemoveAllListeners();
            E_ScooterColors color = default;
            string btnColor = btn.gameObject.name.Split(splitter)[1];
            foreach(var col in EnumUtils.GetEnumList<E_ScooterColors>())
            {
                if(col.ToString().ToLower() == btnColor.ToLower())
                {
                    color = col;
                    break;
                }
            }
            btn.onClick.AddListener(delegate
            {
                ChangeColor(color);
            });
        }
    }

    public void ChangeColor(E_ScooterColors color)
    {
        GameManager.SetColor(color);
        EventsGame.OnChangeSchooterColor(color);
    }
}
