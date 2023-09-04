using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // TODO: Move to scriptable object
    [SerializeField] private Vector3 m_offset;

    private void Update()
    {
        Vector3 newPos = PlayerSingleton.Instance.transform.position;
        newPos.x = transform.position.x;
        transform.position = newPos + m_offset;
    }
}
