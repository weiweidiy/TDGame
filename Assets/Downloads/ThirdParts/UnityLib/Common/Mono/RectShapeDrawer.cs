using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{

    public class RectShapeDrawer : MonoBehaviour, IShapeMaskDrawer
    {
        [SerializeField] Material matRect;
        [SerializeField] Image imgMask;
        [SerializeField] GuideShapeEventPenetrate penetrate;

        private Material _material;
        private Rect _targetRT;

        private float _curWidth;
        private float _curHeight;
        
        private Vector2 center;
        private float _shrinkTime = 0.2f;
        private float _shrinkVelocity = 0f;
        private float _shrinkVelocity2 = 0f;

        /// <summary>
        /// 这里的rt是相对于canvas的坐标
        /// </summary>
        /// <param name="rt"></param>
        public void ShowShapeMask(Rect rt)  
        {
            penetrate.targetRect = rt; // 设置穿透区域
            this.center = new Vector2(rt.x, rt.y);
            _targetRT = rt;

            //设置遮罩材料中的圆心变量
            Vector4 centerMat = new Vector4(center.x, center.y, 0, 0);
            _material = matRect;
            imgMask.material = _material;
            _material.SetVector("_Center", centerMat);

            _curWidth = _targetRT.width * 2;
            _curHeight = _targetRT.height * 2;

            _material.SetFloat("_SliderX", _curWidth);
            _material.SetFloat("_SliderY", _curHeight);

        }

        public void RefreshShape()
        {
            //从当前半径到目标半径差值显示收缩动画
            float valueX = Mathf.SmoothDamp(_curWidth, _targetRT.width, ref _shrinkVelocity, _shrinkTime);
            float valueY = Mathf.SmoothDamp(_curHeight, _targetRT.height + 20, ref _shrinkVelocity2, _shrinkTime);

            if (!Mathf.Approximately(valueX, _curWidth) || !Mathf.Approximately(valueY, _curHeight))
            {
                _curWidth = valueX;
                _curHeight = valueY;

                _material.SetFloat("_SliderX", _curWidth);
                _material.SetFloat("_SliderY", _curHeight);
            }
        }

        private void Update()
        {
            RefreshShape();
        }
    
    }
}