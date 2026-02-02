using Game.Common;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tiktok
{
    public class SamuraiIconDragHandler : CommonUIDragMoveHandler, IPointerClickHandler
    {
        public event Action<object> onClicked;

        public Image iconImage;
        public Transform parent;       // 用于副本显示在最顶

        private CanvasGroup canvasGroup;
        private GameObject dragIconCopy; // 拖拽副本
                                         //private Camera uiCamera;

        private Vector2 dragStartPos; // 记录拖拽起点
        private bool isValidDrag = false; // 是否有效拖拽
        private const float MaxUpAngle = 60f; // 允许的最大向上角度（单位：度）

        protected override void Awake()
        {
            base.Awake();
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        private void DoForParents<T>(Action<T> action) where T : IEventSystemHandler
        {
            Transform parent = transform.parent;
            while (parent != null)
            {
                foreach (var component in parent.GetComponents<Component>())
                {
                    if (component is T)
                        action((T)(IEventSystemHandler)component);
                }
                parent = parent.parent;
            }
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            dragStartPos = eventData.position;
            isValidDrag = false;
            canvasGroup.blocksRaycasts = false;

            DoForParents<IInitializePotentialDragHandler>((parent) => { parent.OnInitializePotentialDrag(eventData); });
            DoForParents<IBeginDragHandler>((parent) => { parent.OnBeginDrag(eventData); });
        }


        public override void OnDrag(PointerEventData eventData)
        {
            Vector2 dragDir = eventData.position - dragStartPos;
            if (!isValidDrag)
            {
                if (dragDir.magnitude < 10f)
                {
                    DoForParents<IDragHandler>((parent) => { parent.OnDrag(eventData); });
                    return;
                }


                float angle = Vector2.Angle(dragDir, Vector2.up);
                if (angle <= MaxUpAngle)
                {
                    isValidDrag = true;
                    CreateDragIconCopy(eventData);
                }
                else
                {
                    // 不是有效布阵拖拽，恢复事件穿透，让滚动条继续响应
                    DoForParents<IDragHandler>((parent) => { parent.OnDrag(eventData); });
                    return;
                }
            }

            if (isValidDrag && dragIconCopy != null)
            {
                Vector3 worldPos;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(
                    parent as RectTransform,
                    eventData.position,
                    uiCamera,
                    out worldPos
                );
                dragIconCopy.transform.position = worldPos;
            }
        }


        public override void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;

            if (dragIconCopy != null)
            {
                Destroy(dragIconCopy);
                dragIconCopy = null;
            }
            isValidDrag = false;
            DoForParents<IEndDragHandler>((parent) => { parent.OnEndDrag(eventData); });
        }


        private void CreateDragIconCopy(PointerEventData eventData)
        {
            dragIconCopy = new GameObject("DragIconCopy");
            dragIconCopy.layer = LayerMask.NameToLayer("UI");
            var image = dragIconCopy.AddComponent<Image>();
            image.sprite = iconImage.sprite;
            image.raycastTarget = false;

            var srcRect = iconImage.rectTransform;
            var copyRect = dragIconCopy.GetComponent<RectTransform>();
            copyRect.sizeDelta = srcRect.sizeDelta;
            copyRect.localScale = srcRect.localScale;
            copyRect.anchorMin = srcRect.anchorMin;
            copyRect.anchorMax = srcRect.anchorMax;
            copyRect.pivot = srcRect.pivot;

            dragIconCopy.transform.SetParent(parent.transform, false);
            dragIconCopy.transform.SetAsLastSibling();

            Vector3 worldPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                parent as RectTransform,
                eventData.position,
                uiCamera,
                out worldPos
            );
            dragIconCopy.transform.position = worldPos;

            dragIconCopy.SetActive(true);
        }

        protected override Camera GetUICamera()
        {
            return GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            onClicked?.Invoke(this.TargetArg);
        }
    }
}


