using Adic;
using Game.Common;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Tiktok
{
    public class StepMaskLevelNode : BaseGuideStep
    {
        [Inject]
        UIManager uiManager;

        [Inject]
        GameLevelNodeViewController levelNodeViewController;

        public string TargetLevelNodeBusinessId { get; set; }

        protected override void Execute(object arg)
        {
            var data = arg as GameLevelNodeViewController.PanelData;
            if(data == null)
            {
                var go = levelNodeViewController.GetNode(TargetLevelNodeBusinessId);
                var collider = go.GetComponent<BoxCollider2D>();
                var rect = GetRectForCanvase(collider, uiManager.GetUIFrameCanvas());
                var uiArgs = new UIGuideController.ControllerArgs
                {
                    TargetRect = rect,
                    MaskType = UIPanelGuideMask.MaskType.Rect,
                    panelName = nameof(UIPanelGuideMask),
                };
                eventManager.Raise<UIGuideController.Open>(uiArgs);
            }
            else
            {
                var extraData = arg as RunableExtraData;
            }
        }


        private Rect GetRectForCanvase(BoxCollider2D collider, Canvas canvas)
        {

            Bounds bounds = collider.bounds;
            Vector3 min = bounds.min;
            Vector3 max = bounds.max;
            float z = collider.transform.position.z;

            Vector3[] result = new Vector3[4];
            // 左下
            result[0] = new Vector3(min.x, min.y, z);
            // 右下
            result[1] = new Vector3(max.x, min.y, z);
            // 右上
            result[2] = new Vector3(max.x, max.y, z);
            // 左上
            result[3] = new Vector3(min.x, max.y, z);


            //Debug.Log(result[0].x + " ," + result[0].y + " ," + result[0].z);
            //Debug.Log(collider.transform.position + " / " + bounds.center);

            var uiCenter = WorldToCanvasPos(canvas, collider.transform.position);
            Vector3[] uiCorners = new Vector3[4];
            for (int i = 0; i < 4; i++)
            {
                Vector2 canvasPos = WorldToCanvasPos(canvas, result[i]);
                uiCorners[i] = new Vector3(canvasPos.x, canvasPos.y, 0);
            }

            // 计算UI坐标下的Rect
            float minX = Mathf.Min(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
            float maxX = Mathf.Max(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
            float minY = Mathf.Min(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);
            float maxY = Mathf.Max(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);

            Rect uiRect = new Rect(
                uiCenter.x,
                uiCenter.y,
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


    }
}

