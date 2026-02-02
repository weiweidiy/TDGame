using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Common
{
    public class UIClickHandler : MonoBehaviour, IPointerClickHandler, IClickHandler
    {
        public event Action<object> onClicked;
        public object TargetArg { get; set; } // 传递数据的参数
        public void OnPointerClick(PointerEventData eventData)
        {
            onClicked?.Invoke(this.TargetArg);
            //Debug.Log($"{gameObject.name} 被点击");

            // 手动分发点击事件到下层对象
            var results = new System.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
           
            foreach (var result in results)
            {
                Debug.Log($"Raycast results count: {result.gameObject} ");
                if (result.gameObject != this.gameObject)
                {
                    Debug.Log($"Raycast results count: {result.gameObject}!!! ");
                    // 查找下层的 IPointerClickHandler 并分发事件
                    var handlers = result.gameObject.GetComponents<IPointerClickHandler>();
                    foreach (var handler in handlers)
                    {
                        Debug.Log($"Raycast results count: {result.gameObject}~~~~ ");
                        handler.OnPointerClick(eventData);
                        break;
                    }
                }
            }
        }
    }
}


