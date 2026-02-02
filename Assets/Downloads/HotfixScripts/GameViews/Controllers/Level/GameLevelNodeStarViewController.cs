using Game.Share;
using JFramework;

namespace Tiktok
{
    public class GameLevelNodeStarViewController : GameLevelNodeBottomViewController
    {
        public GameLevelNodeStarViewController(EventManager eventManager) : base(eventManager)
        {
        }

        protected override string GetPrefabUid(LevelsNodesCfgData cfgData)
        {
            return cfgData.StarPrefabUid;
        }

        /// <summary>
        /// 显示节点
        /// </summary>
        /// <param name="uid"></param>
        public override void ShowNode(string uid)
        {
            base.ShowNode(uid);

            var go = dicRentGameObjects[uid];
            var starsView = go.GetComponent<TiktokLevelNodeStarView>();   
            starsView.UpdateStars(levelsMode.GetNodeProcess(uid));
        }

        protected override void UpdateNode(LevelNodeDTO updatedNode)
        {
            var uid = updatedNode.BusinessId;
            var go = dicRentGameObjects[uid];
            var starsView = go.GetComponent<TiktokLevelNodeStarView>();
            var activeStarCount = starsView.GetActiveStarCount();
            var newStarCount = levelsMode.GetNodeProcess(uid);
            starsView.UpdateStars(newStarCount);
            if (newStarCount > activeStarCount)
            {
                starsView.ReceiveNewStar(newStarCount - 1);
            }
        }
    }
}
