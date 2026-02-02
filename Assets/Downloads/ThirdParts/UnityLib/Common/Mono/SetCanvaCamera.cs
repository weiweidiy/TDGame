
using UnityEngine;

public class SetCanvaCamera : MonoBehaviour
{
    void Awake()
    {
        var mainCamera = Camera.main;
        if (mainCamera != null)
        {
            var _Canvas = GetComponent<Canvas>();
            _Canvas.worldCamera = mainCamera;
        }


    }
}
