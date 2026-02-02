
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// 找到指定tag相机
/// </summary>
[RequireComponent(typeof(Camera))]
public class StackUICamera : MonoBehaviour
{
    void Start()
    {
        var _UICamera = GameObject.FindWithTag("UICamera").GetComponent<Camera>();
        if (_UICamera != null)
        {
            var _Camera = GetComponent<Camera>();
            _Camera.GetUniversalAdditionalCameraData().cameraStack.Add(_UICamera);
        }
    }
}
