using Lean.Touch;
using System;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Common
{
    public class ClickDetector : MonoBehaviour, IClickHandler, IPointerClickHandler
    {
        public event Action<object> onClicked;

        public object TargetArg { get; set; }

        private void OnEnable()
        {
            LeanTouch.OnFingerTap += HandleFingerTap;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerTap -= HandleFingerTap;
        }

        private void HandleFingerTap(LeanFinger finger)
        {
            //// 如果按下时在UI上，直接忽略
            //if (finger.StartedOverGui)
            //    return;

            //// 射线检测点击的物体
            //// 将屏幕坐标转换为世界坐标
            //var ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);
            //var hit = Physics2D.Raycast(ray.origin, ray.direction);

            //if (hit.collider != null && hit.collider.gameObject == gameObject)
            //{
            //    //Debug.Log("点击了这个2D物体");
            //    onClicked?.Invoke(TargetArg);
            //}
            //Debug.Log("ClickDetector HandleFingerTap");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //主相机需要phic 2d recaster
            Debug.Log("ClickDetector OnPointerClick" );
            onClicked?.Invoke(this.TargetArg);
        }
    }
}
