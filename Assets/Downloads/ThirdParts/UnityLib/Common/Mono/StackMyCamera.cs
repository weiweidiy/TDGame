
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StackMyCamera : MonoBehaviour
{
    private void Start()
    {
        var camera = GetComponent<Camera>();
        if(camera == null)
            throw new System.Exception("相机组件为null"+ gameObject.name);

        Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(camera);
    }
}
