using Adic;
using Game.Common;
using JFramework;
using UnityEngine;
using static JFramework.Game.View.UIPanelLevelNodeMenus;


namespace Tiktok
{
    public class EventTriggerLevelNodeEntranceShow : BaseEventTrigger
    {
        [Inject]
        UIManager uiManager;
        public string TargetLevelNodeBusinessId { get; set; }
        public int TargetLevelNodeProcess { get; set; }

        public override void AddListeners()
        {
            eventManager.AddListener<UILevelNodeMenuController.UIControllerEventPanelShowed>(OnLevelNodeEntranceOpen);
        }

        public override void RemoveListeners()
        {
            eventManager.RemoveListener<UILevelNodeMenuController.UIControllerEventPanelShowed>(OnLevelNodeEntranceOpen);
        }

        private void OnLevelNodeEntranceOpen(UILevelNodeMenuController.UIControllerEventPanelShowed e)
        {
            var uiArg = e.Body as UILevelNodeMenuController.ControllerArgs;
            if (uiArg.dto.BusinessId == TargetLevelNodeBusinessId && uiArg.dto.Process == TargetLevelNodeProcess)
            {
                var panel = uiArg.panel;
                var img = panel.GetMenuGameObject(UILevelNodeMenu.Attack);
                var rt = img.GetComponent<RectTransform>();
                Trigger(rt);
            }

        }

        //private object GetRectForCanvas(RectTransform rectTransform, Canvas canvas)
        //{
        //    Vector3[] worldCorners = new Vector3[4];
        //    rectTransform.GetWorldCorners(worldCorners);
        //    Vector3[] uiCorners = new Vector3[4];
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Vector2 canvasPos = WorldToCanvasPos(canvas, worldCorners[i]);
        //        uiCorners[i] = new Vector3(canvasPos.x, canvasPos.y, 0);
        //    }
        //    // 计算UI坐标下的Rect
        //    float minX = Mathf.Min(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
        //    float maxX = Mathf.Max(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
        //    float minY = Mathf.Min(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);
        //    float maxY = Mathf.Max(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);
        //    Rect uiRect = new Rect(
        //        (minX + maxX) / 2,
        //        (minY + maxY) / 2,
        //        maxX - minX,
        //        maxY - minY
        //    );
        //    return uiRect;

        //}

        //protected Vector2 WorldToCanvasPos(Canvas canvas, Vector3 world)

        //{
        //    Vector2 position;

        //    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
        //        world, canvas.GetComponent<Camera>(), out position);

        //    return position;
        //}
    }
}

