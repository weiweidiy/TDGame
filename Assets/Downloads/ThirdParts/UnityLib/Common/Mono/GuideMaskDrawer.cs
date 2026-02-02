using UnityEngine;

namespace Game.Common
{
    public class GuideMaskDrawer : MonoBehaviour
    {
        [SerializeField] RectShapeDrawer rectDrawer;
        [SerializeField] CycleShapeDrawer cycleDrawer;
        [SerializeField] ParallelogramShapeDrawer parallelogramDrawer;


        public void ShowRect(Rect rt)
        {
            cycleDrawer.enabled = false;
            parallelogramDrawer.enabled = false;
            rectDrawer.enabled = true;
            if (rectDrawer == null)
                rectDrawer = GetComponent<RectShapeDrawer>();

            if (rectDrawer != null)
            {
                rectDrawer.ShowShapeMask(rt);
            }
        }

        public void ShowCycle(Rect rt)
        {
            rectDrawer.enabled = false;
            parallelogramDrawer.enabled = false;
            cycleDrawer.enabled = true;
            if (cycleDrawer == null)
                cycleDrawer = GetComponent<CycleShapeDrawer>();
            if (cycleDrawer != null)
            {
                cycleDrawer.ShowShapeMask(rt);
            }
        }

        public void ShowParallelogram(Rect rt, float skew)
        {
            cycleDrawer.enabled = false;
            rectDrawer.enabled = false;
            parallelogramDrawer.enabled = true;
            if (parallelogramDrawer == null)
                parallelogramDrawer = GetComponent<ParallelogramShapeDrawer>();
            if (parallelogramDrawer != null)
            {
                parallelogramDrawer.Skew = skew;
                parallelogramDrawer.ShowShapeMask(rt);
            }
        }


    }
}