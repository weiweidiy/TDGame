using Adic;
using Game.Common;
using JFramework;
using UnityEngine;


namespace Tiktok
{
    /// <summary>
    /// 监听关卡进入触发
    /// </summary>
    public class EventTriggerLevelEnter : BaseEventTrigger
    {
        //[Inject]
        //LevelsModel levelsModel;

        public string targetLevelBusinessId = string.Empty;
        //public int targetLevelNodeProcess = 0;
        public override void AddListeners()
        {
            eventManager.AddListener<GameLevelBackgroundViewController.EventEnterLevel>(OnLevelOpen);
        }

        public override void RemoveListeners()
        {
            eventManager.RemoveListener<GameLevelBackgroundViewController.EventEnterLevel>(OnLevelOpen);
        }

        private void OnLevelOpen(GameLevelBackgroundViewController.EventEnterLevel e)
        {
            var levelBusinessId = e.Body as string;
            //var targetNode = levelsModel.Get(targetLevelBusinessId);

            if (levelBusinessId == targetLevelBusinessId)
            {
                //Debug.Log("引导第一步开始");
                //var go = levelNodeViewController.GetNode(targetLevelBusinessId);
                //var collider = go.GetComponent<BoxCollider2D>();
                //var rect = GetRectForCanvase(collider, uiManager.GetUIFrameCanvas());


                Trigger(null);
            }
        }

        //private Rect GetRectForCanvase(BoxCollider2D collider, Canvas canvas)
        //{

        //    Bounds bounds = collider.bounds;
        //    Vector3 min = bounds.min;
        //    Vector3 max = bounds.max;
        //    float z = collider.transform.position.z;

        //    Vector3[] result = new Vector3[4];
        //    // 左下
        //    result[0] = new Vector3(min.x, min.y, z);
        //    // 右下
        //    result[1] = new Vector3(max.x, min.y, z);
        //    // 右上
        //    result[2] = new Vector3(max.x, max.y, z);
        //    // 左上
        //    result[3] = new Vector3(min.x, max.y, z);


        //    //Debug.Log(result[0].x + " ," + result[0].y + " ," + result[0].z);
        //    //Debug.Log(collider.transform.position + " / " + bounds.center);

        //    var uiCenter = WorldToCanvasPos(canvas, collider.transform.position);
        //    Vector3[] uiCorners = new Vector3[4];
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Vector2 canvasPos = WorldToCanvasPos(canvas, result[i]);
        //        uiCorners[i] = new Vector3(canvasPos.x, canvasPos.y, 0);
        //    }

        //    // 计算UI坐标下的Rect
        //    float minX = Mathf.Min(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
        //    float maxX = Mathf.Max(uiCorners[0].x, uiCorners[1].x, uiCorners[2].x, uiCorners[3].x);
        //    float minY = Mathf.Min(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);
        //    float maxY = Mathf.Max(uiCorners[0].y, uiCorners[1].y, uiCorners[2].y, uiCorners[3].y);

        //    Rect uiRect = new Rect(
        //        uiCenter.x,
        //        uiCenter.y,
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

