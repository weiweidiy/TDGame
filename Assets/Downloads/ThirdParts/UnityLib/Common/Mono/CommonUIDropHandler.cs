using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Common
{
    public class CommonUIDropHandler : MonoBehaviour, IDropHandler
    {
        //public int pointIndex; // 阵型点位编号
        public event Action<object> onDrop;

        // 缩小范围比例（如0.9表示缩小10%）
        public float RangeScale = 1f; // 可在Inspector中调整，缩放范围

        public virtual void OnDrop(PointerEventData eventData)
        {
            Debug.Log($"OnDrop: {eventData.pointerDrag?.name} on {gameObject.name}");
            var rectTransform = transform as RectTransform;
            Vector2 localPoint;
            // 将屏幕坐标转为当前RectTransform的本地坐标
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out localPoint))
            {
                // 获取原始rect
                var rect = rectTransform.rect;
                // 缩小rect
                var shrinkedRect = new Rect(
                    rect.x + rect.width * (1 - RangeScale) / 2,
                    rect.y + rect.height * (1 - RangeScale) / 2,
                    rect.width * RangeScale,
                    rect.height * RangeScale
                );
                
                if (shrinkedRect.Contains(localPoint))
                {
                    var target = GetComponent(eventData);
                    if (target != null)
                    {
                        onDrop?.Invoke(target.TargetArg);
                    }
                }
                // 否则不处理（可加提示或回弹等逻辑）
            }
        }

        protected virtual CommonUIDragMoveHandler GetComponent(PointerEventData eventData)
        {
            return eventData.pointerDrag?.GetComponent<CommonUIDragMoveHandler>();
        }
    }
}

