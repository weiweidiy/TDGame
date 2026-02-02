using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 图形遮罩，可以穿透
/// </summary>
public class ShapeMask : MonoBehaviour, ICanvasRaycastFilter
{
    public Image _Mask; //遮罩图片
    private Material _materia;
    private GameObject target;

    private void Awake()
    {
        _materia = _Mask.material;
    }

    /// <summary>
    /// 创建圆角矩形区域
    /// </summary>
    /// <param name="pos">矩形的屏幕位置</param>
    /// <param name="pos1">左下角位置</param>
    /// <param name="pos2">右上角位置</param>
    public void CreateCircleRectangleMask(Vector2 pos, Vector2 widthAndHeight, float raid, bool isHorizontal = true)
    {
        _materia.SetFloat("_MaskType", isHorizontal ? 2f : 3f);
        _materia.SetVector("_Origin", new Vector4(pos.x, pos.y, widthAndHeight.x, widthAndHeight.y));
        _materia.SetFloat("_Raid", raid);
    }

    /// <summary>
    /// 创建矩形点击区域
    /// </summary>
    /// <param name="pos">矩形中心点坐标</param>
    /// <param name="widthAndHeight">矩形宽高</param>
    public void CreateRectangleMask(Vector2 pos, Vector2 widthAndHeight, float raid)
    {
        _materia.SetFloat("_MaskType", 1f);
        _materia.SetVector("_Origin", new Vector4(pos.x, pos.y, widthAndHeight.x, widthAndHeight.y));
    }

    /// <summary>
    /// 创建双圆形点击区域
    /// </summary>
    /// <param name="pos">大圆形中心点坐标</param>
    /// <param name="rad">大圆形半径</param>
    /// <param name="pos1">小圆形中心点坐标</param>
    /// <param name="rad1">小圆形半径</param>
    public void CreateCircleMask(Vector3 pos, float rad, Vector3 pos1, float rad1)
    {
        _materia.SetFloat("_MaskType", 0f);
        _materia.SetVector("_Origin", new Vector4(pos.x, pos.y, rad, 0));
        _materia.SetVector("_TopOri", new Vector4(pos1.x, pos1.y, rad1, 0));
    }

    /// <summary>
    /// 设置目标不被Mask遮挡
    /// </summary>
    /// <param name="tg">目标</param>
    public void SetTargetImage(GameObject tg)
    {
        target = tg;
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        //没有目标则捕捉事件渗透
        if (target == null)
        {
            return true;
        }

        //在目标范围内做事件渗透
        return !RectTransformUtility.RectangleContainsScreenPoint(target.GetComponent<RectTransform>(),
            sp, eventCamera);
    }
}