using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private int keyId = 0;

    public int GetKeyId()
    {
        return keyId;
    }
}