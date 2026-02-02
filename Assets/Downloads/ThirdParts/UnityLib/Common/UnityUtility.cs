using JFramework;
using UnityEngine;

namespace Game.Common
{
    public class UnityUtility : Utility
    {
        /// <summary>
        /// 将世界坐标转换为UI坐标
        /// </summary>
        /// <param name="worldPosition">世界坐标</param>
        /// <param name="camera">用于渲染世界的摄像机</param>
        /// <param name="uiRectTransform">目标UI的RectTransform</param>
        /// <returns>UI坐标（相对于RectTransform）</returns>
        public Vector2 WorldToUIPosition(Vector3 worldPosition, Camera camera, RectTransform uiRectTransform)
        {
            // 将世界坐标转换为屏幕坐标
            Vector3 screenPos = camera.WorldToScreenPoint(worldPosition);

            // 将屏幕坐标转换为UI坐标
            Vector2 uiPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                uiRectTransform,
                screenPos,
                camera,
                out uiPos
            );
            return uiPos;
        }
    }
}

