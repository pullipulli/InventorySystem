using UnityEngine;

public class Character : MonoBehaviour
{
    private GameObject _itemPreviewSocket;
    public GameObject ItemPreviewSocket {get => _itemPreviewSocket; }
    private void Awake()
    {
        _itemPreviewSocket = transform.GetChild(0).gameObject;
    }
}