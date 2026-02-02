using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class GuideShapeEventPenetrate : MonoBehaviour, ICanvasRaycastFilter
    {
        ///// <summary>
        ///// 作为目标点击事件渗透区域
        ///// </summary>
        //public Image target;

        //public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        //{
        //    //没有目标则捕捉事件渗透
        //    if (target == null)
        //    {
        //        return true;
        //    }

        //    //在目标范围内做事件渗透
        //    return !RectTransformUtility.RectangleContainsScreenPoint(target.rectTransform,
        //        sp, eventCamera);
        //}

        public Rect targetRect; // 由RectShapeDrawer动态赋值

        float k = 1f;

        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            // 将屏幕坐标sp转换为Canvas本地坐标
            RectTransform rt = GetComponent<RectTransform>();
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, sp, eventCamera, out localPoint))
            {
                Debug.Log($"GuideShapeEventPenetrate IsRaycastLocationValid localPoint:{localPoint} targetRect:{targetRect}");
                //return false;
                if (localPoint.x > targetRect.x - targetRect.width / k &&
                   localPoint.x < targetRect.x /*+ targetRect.width / k*/ &&
                   localPoint.y > targetRect.y - targetRect.height / k &&
                   localPoint.y < targetRect.y + targetRect.height / k)
                {
                    return false;
                }
                
            }
            // 其它区域正常拦截
            return true;
        }
    }

    //public class RectShapeRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
    //{
    //    public Rect targetRect; // 由RectShapeDrawer动态赋值

    //    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    //    {
    //        // 将屏幕坐标sp转换为Canvas本地坐标
    //        RectTransform rt = GetComponent<RectTransform>();
    //        Vector2 localPoint;
    //        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, sp, eventCamera, out localPoint))
    //        {
    //            // 判断localPoint是否在targetRect内
    //            if (targetRect.Contains(localPoint))
    //            {
    //                // 穿透：返回false，表示不拦截点击
    //                return false;
    //            }
    //        }
    //        // 其它区域正常拦截
    //        return true;
    //    }
    //}
}