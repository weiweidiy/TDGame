using Game.Common;
using UnityEngine.EventSystems;

namespace Tiktok
{
    public class DeploySamuraiRetreatHandler : CommonUIDropHandler
    {
        protected override CommonUIDragMoveHandler GetComponent(PointerEventData eventData)
        {
            return eventData.pointerDrag?.GetComponent<DeploySamuraiIconDragHandler>();
        }
    }
}


