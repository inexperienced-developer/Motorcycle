using UnityEngine;

public class UIMobile : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_IOS && !UNITY_ANDROID
        gameObject.SetActive(false);
#endif
    }
}
