using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using UnityEngine;
using static Tiktok.UIGuideController;


namespace Tiktok
{
    public class StepMaskUIObject : BaseGuideStep
    {
        [Inject]
        UIManager uiManager;

        public UIPanelGuideMask.MaskType MaskType = UIPanelGuideMask.MaskType.Rect;

        public RectTransform targetRt;

        public FingerType fingerType;

        protected override void Execute(object arg)
        {
            // 优先使用配置的targetRt
            if (targetRt != null)
            {
                arg = targetRt;
            }

            var rt = arg as RectTransform;

            if(rt == null)
            {
                var extraData = arg as RunableExtraData;
                rt = extraData.Data as RectTransform;            
            }

            if(rt == null)
            {
                Debug.LogError("StepMaskUIObject Execute failed, RectTransform is null");
                return;
            }

            var canvasPos = WorldToUICanvasPosition(rt.position, uiManager.GetUIFrameCanvas());
            var rect = new Rect(canvasPos.x, canvasPos.y, rt.rect.width, rt.rect.height);

            //finger = goManager.Rent(configManager.GetFingerIconPath());
            var uiArgs = new UIGuideController.ControllerArgs
            {
                TargetRect = rect,
                MaskType = MaskType,
                FingerType = fingerType,
                panelName = nameof(UIPanelGuideMask),
            };

            eventManager.Raise<UIGuideController.Open>(uiArgs);
        }

        protected override void OnCompleteTrigger(object arg)
        {
            var controllerArgs = new UIGuideController.ControllerArgs
            {
                panelName = nameof(UIPanelGuideMask),
            };
            eventManager.Raise<UIGuideController.Close>(controllerArgs);
            base.OnCompleteTrigger(arg);         
        }


        private object GetRectForCanvas(RectTransform rectTransform, Canvas canvas)
        {
            Vector3[] worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);
            Vector3[] uiCorners = new Vector3[4];
            for (int i = 0; i < 4; i++)
            {
                Vector2 canvasPos = WorldToCanvasPos(canvas, worldCorners[i]);
                uiCorners[i] = new Vector3(canvasPos.x, canvasPos.y, 0);
            }
            // 计算UI坐标下的Rect
            float minX = Mathf.Min(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
            float maxX = Mathf.Max(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
            float minY = Mathf.Min(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);
            float maxY = Mathf.Max(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);
            Rect uiRect = new Rect(
                (minX + maxX) / 2,
                (minY + maxY) / 2,
                maxX - minX,
                maxY - minY
            );
            return uiRect;

        }

        protected Vector2 WorldToCanvasPos(Canvas canvas, Vector3 world)

        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                world, canvas.GetComponent<Camera>(), out position);

            return position;
        }

        public Vector2 GetCanvasPosition(RectTransform rectTransform, Canvas canvas)
        {
            // 获取世界坐标
            Vector3[] worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);

            // 取左下角为例
            Vector3 worldPos = worldCorners[0];

            // 获取 Canvas 的 RectTransform
            RectTransform canvasRect = canvas.transform as RectTransform;

            // 获取用于渲染 Canvas 的摄像机
            Camera cam = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;

            // 转换为 Canvas 本地坐标
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, worldPos, cam, out localPoint);

            return localPoint;
        }

        public Vector2 WorldToUICanvasPosition(Vector3 worldPosition, Canvas canvas)
        {
            // 获取用于渲染 Canvas 的摄像机
            Camera cam = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;

            // 世界坐标转屏幕坐标
            Vector3 screenPos = cam != null ? cam.WorldToScreenPoint(worldPosition) : worldPosition;

            // 转换为 Canvas 下的本地坐标
            Vector2 uiPos;
            RectTransform canvasRect = canvas.transform as RectTransform;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, cam, out uiPos);

            return uiPos;
        }
    }
}

