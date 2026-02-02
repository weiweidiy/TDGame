using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class CycleShapeDrawer : MonoBehaviour, IShapeMaskDrawer
    {
        [SerializeField] Material matCycle;
        [SerializeField] Image imgMask;
        private Material _material;
        private Rect _targetRT;
        private float _curRadius;
        private Vector2 center;
        private float _shrinkTime = 0.2f;
        private float _shrinkVelocity = 0f;
        /// <summary>
        /// 这里的rt是相对于canvas的坐标
        /// </summary>
        /// <param name="rt"></param>
        public void ShowShapeMask(Rect rt)
        {
            this.center = new Vector2(rt.x , rt.y );
            _targetRT = rt;
            //设置遮罩材料中的圆心变量
            Vector4 centerMat = new Vector4(center.x, center.y, 0, 0);
            _material = matCycle;
            imgMask.material = _material;
            _material.SetVector("_Center", centerMat);
            //计算出矩形区域的外接圆半径
            _curRadius = Mathf.Sqrt(Mathf.Pow(_targetRT.width / 2, 2) + Mathf.Pow(_targetRT.height / 2, 2)) * 2;
            _material.SetFloat("_Slider", _curRadius);
        }
        public void RefreshShape()
        {
            //从当前半径到目标半径差值显示收缩动画
            float targetRadius = Mathf.Sqrt(Mathf.Pow(_targetRT.width / 2, 2) + Mathf.Pow(_targetRT.height / 2, 2));
            float value = Mathf.SmoothDamp(_curRadius, targetRadius, ref _shrinkVelocity, _shrinkTime);
            if (!Mathf.Approximately(value, _curRadius))
            {
                _curRadius = value;
                _material.SetFloat("_Slider", _curRadius);
            }
        }
        private void Update()
        {
            RefreshShape();
        }
    }
}