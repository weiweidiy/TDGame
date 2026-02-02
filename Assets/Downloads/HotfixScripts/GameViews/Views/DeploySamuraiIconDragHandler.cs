using Game.Common;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tiktok
{
    public class DeploySamuraiIconDragHandler : CommonUIDragMoveHandler, IPointerClickHandler
    {
        public event Action<object> onClicked;
        private GameObject dragCopy; // 拖拽副本
        public Transform parent;
        public Image iconImage;

        protected override Camera GetUICamera()
        {
            return GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            CreateDragCopy(eventData);
            SetDragCopyPosition(eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            SetDragCopyPosition(eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (dragCopy != null)
            {
                Destroy(dragCopy);
                dragCopy = null;
            }
        }

        private void CreateDragCopy(PointerEventData eventData)
        {
            if (dragCopy != null) return;

            dragCopy = new GameObject("DragIconCopy");
            dragCopy.layer = LayerMask.NameToLayer("UI");
            var image = dragCopy.AddComponent<Image>();
            image.sprite = iconImage.sprite;
            image.raycastTarget = false;

            var srcRect = iconImage.rectTransform;
            var copyRect = dragCopy.GetComponent<RectTransform>();
            copyRect.sizeDelta = srcRect.sizeDelta;
            copyRect.localScale = srcRect.localScale;
            copyRect.anchorMin = srcRect.anchorMin;
            copyRect.anchorMax = srcRect.anchorMax;
            copyRect.pivot = srcRect.pivot;

            dragCopy.transform.SetParent(parent.transform, false);
            dragCopy.transform.SetAsLastSibling();

            Vector3 worldPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                parent as RectTransform,
                eventData.position,
                uiCamera,
                out worldPos
            );
            dragCopy.transform.position = worldPos;

            dragCopy.SetActive(true);
        }

        private void SetDragCopyPosition(PointerEventData eventData)
        {
            if (dragCopy == null) return;
            var canvasRect = dragCopy.transform.parent as RectTransform;
            Vector3 worldPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                canvasRect,
                eventData.position,
                uiCamera,
                out worldPos
            );
            dragCopy.transform.position = worldPos;
        }

        // 新增鼠标点击事件监听
        public void OnPointerClick(PointerEventData eventData)
        {
            onClicked?.Invoke(this.TargetArg);
            // 在这里处理点击事件
            Debug.Log("DeploySamuraiIcon 被点击");
        }
    }
}


