using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class ParallelogramShapeDrawer : MonoBehaviour, IShapeMaskDrawer
    {
        [SerializeField] Material matParallelogram;
        [SerializeField] Image imgMask;
        [SerializeField] GuideShapeEventPenetrate penetrate;

        public float Skew { get; set; }

        private Material _material;
        private Rect _targetRT;

        private float _curWidth;
        private float _curHeight;
        private float _curSkew;

        private Vector2 center;
        private float _shrinkTime = 0.2f;
        private float _shrinkVelocity = 0f;
        private float _shrinkVelocity2 = 0f;
        private float _shrinkVelocitySkew = 0f;

        /// <summary>
        /// 显示平行四边形遮罩，skew为斜率（正负均可）
        /// </summary>
        public void ShowShapeMask(Rect rt)
        {
            penetrate.targetRect = rt;
            this.center = new Vector2(rt.x, rt.y);
            _targetRT = rt;

            Vector4 centerMat = new Vector4(center.x, center.y, 0, 0);
            _material = matParallelogram;
            imgMask.material = _material;
            _material.SetVector("_Center", centerMat);

            _curWidth = _targetRT.width * 2;
            _curHeight = _targetRT.height * 2;
            _curSkew = Skew;

            _material.SetFloat("_SliderX", _curWidth);
            _material.SetFloat("_SliderY", _curHeight);
            _material.SetFloat("_Skew", _curSkew);
        }

        public void RefreshShape()
        {
            float valueX = Mathf.SmoothDamp(_curWidth, _targetRT.width, ref _shrinkVelocity, _shrinkTime);
            float valueY = Mathf.SmoothDamp(_curHeight, _targetRT.height + 20, ref _shrinkVelocity2, _shrinkTime);
            float valueSkew = Mathf.SmoothDamp(_curSkew, _curSkew, ref _shrinkVelocitySkew, _shrinkTime);

            if (!Mathf.Approximately(valueX, _curWidth) || !Mathf.Approximately(valueY, _curHeight) || !Mathf.Approximately(valueSkew, _curSkew))
            {
                _curWidth = valueX;
                _curHeight = valueY;
                _curSkew = valueSkew;

                _material.SetFloat("_SliderX", _curWidth);
                _material.SetFloat("_SliderY", _curHeight);
                _material.SetFloat("_Skew", _curSkew);
            }
        }

        private void Update()
        {
            RefreshShape();
        }


    }
}