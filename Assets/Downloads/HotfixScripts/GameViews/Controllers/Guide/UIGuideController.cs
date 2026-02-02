using Adic;
using Game.Common;
using JFramework;
using JFramework.Game.View;
using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Event = JFramework.Event;



namespace Tiktok
{
    public class UIGuideController : ViewController
    {
        public enum FingerType
        {
            None,
            Tap,
            Swipe,        
        }
        //public class Open : Event { }
        //public class Close : Event { }

        public class ControllerArgs : ControllerBaseArgs
        {
            public Rect TargetRect;
            public UIPanelGuideMask.MaskType MaskType = UIPanelGuideMask.MaskType.Rect;
            public FingerType FingerType;
        }

        //[Inject]
        //UIManager uiManager;

        [Inject]
        TiktokGameObjectManager goManager;

        [Inject]
        TiktokConfigManager configManager;

        GameObject finger;

        public UIGuideController(EventManager eventManager) : base(eventManager)
        {
        }




        protected override void DoOpen(Open e)
        {
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            var rect = controllerArgs.TargetRect;
            //Debug.Log($"UIGuideController DoOpen TargetRect:{rect} MaskType:{controllerArgs.MaskType} FingerType:{controllerArgs.FingerType}");
            var maskType = controllerArgs.MaskType;
            var properties = new UIPanelGuideProperties
            {
                TargetRT = rect,
                maskType = maskType
            };
            var controller = uiManager.ShowPanel(controllerArgs.panelName, properties);

            if(controllerArgs.FingerType != FingerType.None)
            {
                if(finger != null)
                {
                    goManager.Return(finger);
                    finger = null;
                }

                finger = RentFinger(controllerArgs.FingerType);

                finger.transform.SetParent((controller as UIPanelGuideMask).transform);
                finger.transform.localScale = Vector3.one;
                finger.transform.localPosition = new Vector3(rect.x , rect.y, 0);
            }
        }

        private GameObject RentFinger(FingerType fingerType)
        {
            switch(fingerType)
            {
                case FingerType.Tap:
                    return goManager.Rent(configManager.GetFingerIconPath());
                case FingerType.Swipe:
                    return goManager.Rent(configManager.GetFingerSwipeIconPath());
                default:
                    throw new Exception("Invalid FingerType " + fingerType);
            }
        }

        //private void OnClose(Close e)
        //{
        //    if (finger != null)
        //    {
        //        goManager.Return(finger);
        //        finger = null;
        //    }

        //    uiManager.HidePanel(nameof(UIPanelGuideMask));
        //}

        protected override void DoClose(Close e)
        {
            base.DoClose(e);
            var controllerArgs = e.Body as ControllerArgs;
            if (controllerArgs == null) return;

            if (finger != null)
            {
                goManager.Return(finger);
                finger = null;
            }

            uiManager.HidePanel(controllerArgs.panelName);
        }
    }
}
