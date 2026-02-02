using JFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Common
{
    public interface IDialogPanel
    {
        Task Say(string content, BaseDialogPlayer.Position pos, Sprite leftHead, Sprite rightHead);
    }

    public abstract class BaseDialogPlayer : BaseRunableAsync
    {
        public class DialogData
        {
            public string Speaker;
            public Position Pos;
            public string Content;
            public Sprite leftHead;
            public Sprite rightHead;
            public DialogType Type;
            //public float Duration;
        }

        public enum Position
        {
            Left,
            Right,
            Center
        }

        public enum DialogType
        {
            Say,
            Menu,
        }

        protected override async Task OnStartAync(RunableExtraData extraData)
        {
            await base.OnStartAync(extraData);

            var dialogDataList = extraData.Data as List<DialogData>;

            //play dialog
            var que = new Queue<DialogData>(dialogDataList);
            while (que.Count > 0)
            {
                if (!IsRunning)
                    break;

                var dialogData = que.Dequeue();
                await PlayDialog(dialogData);
                //await Task.Yield();

                //Debug.Log($"Dialog played complete: {dialogData.Content}");
            }

            Stop();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected abstract Task PlayDialog(DialogData dialogData);
    }
}


