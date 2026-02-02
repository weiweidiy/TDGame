using JFramework.Game;
using UnityEngine;

namespace Tiktok
{

    public class TiktokBackgroundView : MonoBehaviour
    {
        [SerializeField] Transform[] nodes;

        [SerializeField] SpriteRenderer background;

        public Transform GetNode(int index)
        {
            if(index >= nodes.Length)
                throw new System.Exception("背景节点索引越界 " + index);
            return nodes[index];
        }

        public void SetBackground(Sprite sprite)
        {
            if (sprite == null)
            {
                Debug.LogError("背景图片不能为空");
                return;
            }
            background.sprite = sprite;
        }

    }
}
