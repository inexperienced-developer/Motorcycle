using UnityEngine;

[CreateAssetMenu(menuName = "General/Container/GameObject", fileName = "container_obj")]
public class ObjectContainer : ScriptableObject
{
    [SerializeField] private GameObject[] m_objs;
    public GameObject[] Objs => m_objs;
}
