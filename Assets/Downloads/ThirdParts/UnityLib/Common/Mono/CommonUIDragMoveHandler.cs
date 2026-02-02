using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Common
{
    /// <summary>
    /// 通用UI拖拽移动组件，直接拖动原始对象，不创建副本
    /// 挂载到任意UI对象即可
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public abstract class CommonUIDragMoveHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        /// <summary>
        /// 目标的额外参数
        /// </summary>
        public object TargetArg { get; set; } // 可用于传递额外参数

        protected Camera uiCamera;

        protected virtual void Awake()
        {
            uiCamera = GetUICamera();
            if (uiCamera == null)
            {
                Debug.LogError("UI Camera is not set or found.");
            }
        }

        protected abstract Camera GetUICamera();

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
        }

        public virtual void OnDrag(PointerEventData eventData)
        {
            Vector3 worldPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                transform.parent as RectTransform,
                eventData.position,
                uiCamera,
                out worldPos
            );
            transform.position = worldPos;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            // 可在此处理拖拽结束后的逻辑
        }
    }
}
