using Adic;
using EnhancedScrollerAdvance;
using Game.Share;
using JFramework;
using JFramework.Game.View;
using System.Collections.Generic;
using Tiktok;


namespace Tiktok
{
    public class UIScrollerUnitViewDataConverter
    {
        [Inject]
        TiktokSpritesManager spritesManager;

        [Inject]
        TiktokConfigManager tiktokConfigManager;

        [Inject]
        ILanguageManager languageManager;

        [Inject]
        TiktokGameDataManager tiktokGameDataManager;

        public List<EnhancedDataV2> Convert(List<SamuraiDTO> samuraiDTOs)
        {
            //samuraiDTOs按ID排序
            samuraiDTOs.Sort((a, b) => a.Id.CompareTo(b.Id));

            var result = new List<EnhancedDataV2>();
            foreach (var dto in samuraiDTOs)
            {
                var data = new EnhancedDataV2();
                var unitData = new UISamuraiScrollerUnitView.UnitData();
                unitData.dto = dto;
                unitData.headIcon = spritesManager.GetSprite(tiktokConfigManager.GetSamuraiHeadIconBusinessId(dto.BusinessId));
                unitData.rareIcon = spritesManager.GetSprite(tiktokConfigManager.GetSamuraiRareIconBusinessId(dto.BusinessId));
                unitData.name = languageManager.GetText(tiktokConfigManager.GetSamuraiNameLid(dto.BusinessId));
                unitData.samuraiInfo = tiktokGameDataManager.GetSamuraiDetailInfo(dto.Id);
                data.UnitData = unitData;
                result.Add(data);
            }
            return result;
        }

        public List<EnhancedDataV2> Convert(List<LevelNodeDTO> levelNodeDtos)
        {
            var result = new List<EnhancedDataV2>();
            var levelUids = new HashSet<string>();
            foreach (var dto in levelNodeDtos)
            {
                var uid = dto.BusinessId;
                var levelUid = tiktokConfigManager.GetLevelUid(uid);
                if (levelUids.Contains(levelUid))
                    continue;
                levelUids.Add(levelUid);
            }

            foreach (var levelUid in levelUids)
            {
                var data = new EnhancedDataV2();
                var unitData = new UILevelListScrollerUnitView.UnitData();
                unitData.levelUid = levelUid;
                unitData.name = languageManager.GetText(tiktokConfigManager.GetLevelNameLid(levelUid));
                var process = tiktokGameDataManager.GetLevelTotalStars(levelUid) / (float)tiktokConfigManager.GetLevelMaxStars(levelUid);
                unitData.progress = (int)(process * 100) + "%";
                unitData.fillAmount = process;
                //unitData.levelIcon = spritesManager.GetSprite(tiktokConfigManager.GetLevelIconBusinessId(levelUid));
                data.UnitData = unitData;
                result.Add(data);
            }

            return result;
        }
    }
}
