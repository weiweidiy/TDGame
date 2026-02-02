using Game.Common;
using System.Threading.Tasks;

namespace Tiktok
{
    public class TiktokDialogPlayer : BaseDialogPlayer
    {
        IDialogPanel dialogPanel;
        public TiktokDialogPlayer(IDialogPanel dialogPanel)
        {
            this.dialogPanel = dialogPanel;
        }

        protected override Task PlayDialog(DialogData dialogData)
        {
            switch(dialogData)
            {
                case { Type: DialogType.Say }:
                    return dialogPanel.Say(dialogData.Content, dialogData.Pos, dialogData.leftHead, dialogData.rightHead);
                default:
                    throw new System.Exception($"Unsupported dialog type: {dialogData.Type}");
            }
        }
    }
}

