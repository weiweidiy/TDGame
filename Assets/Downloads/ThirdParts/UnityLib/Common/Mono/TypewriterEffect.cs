using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System; // 如果用 TextMeshPro

namespace Game.Common
{
    /// <summary>
    /// 打字机效果脚本
    /// </summary>
    //[RequireComponent(typeof(TextMeshProUGUI))] // 或 [RequireComponent(typeof(TMP_Text))]
    public class TypewriterEffect : MonoBehaviour
    {
        public event Action onTypingComplete;
        [SerializeField] TextMeshProUGUI uiText; // 或 TMP_Text uiText;
        [SerializeField] float typeSpeed = 0.05f;


        private string fullText;
        private bool isTyping = false;
        private bool skip = false;

        public bool IsTyping => isTyping;



        public void Play(string text)
        {
            fullText = text;
            uiText.text = "";
            skip = false;
            StartCoroutine(TypeText());
        }

        private IEnumerator TypeText()
        {
            isTyping = true;
            for (int i = 0; i < fullText.Length; i++)
            {
                if (skip)
                {
                    uiText.text = fullText;
                    break;
                }
                uiText.text += fullText[i];
                yield return new WaitForSeconds(typeSpeed);
            }
            isTyping = false;
            onTypingComplete?.Invoke();
        }

        public void Skip()
        {
            if (isTyping)
            {
                skip = true;
            }
        }

        //void Update()
        //{
        //    // 可根据你的UI逻辑改为按钮事件
        //    if (isTyping && Input.GetMouseButtonDown(0))
        //    {
        //        skip = true;
        //    }
        //}
    }
}