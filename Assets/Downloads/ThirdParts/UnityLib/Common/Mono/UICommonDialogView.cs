using Game.Common;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Common
{
    public class UICommonDialogView : MonoBehaviour, IDialogPanel
    {
        [SerializeField] TypewriterEffect typewriterEffect;
        [SerializeField] GameObject dialogFramework;
        [SerializeField] AdvancedButton btnNext;
        [SerializeField] Image leftHead;
        [SerializeField] Image rightHead;
        [SerializeField] GameObject leftHeadFramework;
        [SerializeField] GameObject rightHeadFramework;

        protected TaskCompletionSource<bool> tcs = null;


        private void Awake()

        {
            btnNext.onClick.AddListener(OnNextClicked);
        }

        private void OnDestroy()
        {
            btnNext.onClick.RemoveAllListeners();

        }

        private void OnNextClicked()
        {
            if (typewriterEffect.IsTyping)
            {
                typewriterEffect.Skip();
                return;
            }

            Debug.Log($"OnNextClicked. tcs is null: {tcs == null}, tcs.Task.IsCompleted: {tcs?.Task.IsCompleted}");
            tcs?.TrySetResult(true);
        }

        public async Task Say(string content, BaseDialogPlayer.Position pos, Sprite leftHead, Sprite rightHead)
        {
            //this.tcs = tcs == null ? new TaskCompletionSource<bool>() : tcs;
            if (tcs == null || tcs.Task.IsCompleted)
                tcs = new TaskCompletionSource<bool>();

            dialogFramework.SetActive(true);
            typewriterEffect.Play(content);
            this.leftHeadFramework.gameObject.SetActive(leftHead != null);
            if (leftHead != null)
                this.leftHead.sprite = leftHead;

            this.rightHeadFramework.gameObject.SetActive(rightHead != null);
            if (rightHead != null)
                this.rightHead.sprite = rightHead;


            await tcs.Task;
        }
    }
}
