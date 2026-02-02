using UnityEngine;
using System.Collections;
using TMPro;

public class TMPNumberRoller : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public float duration = 0.5f;

    private Coroutine rollingCoroutine;

    private void Start()
    {
        targetText = GetComponent<TextMeshProUGUI>();
    }

    public void RollTo(int targetValue)
    {
        if (rollingCoroutine != null)
            StopCoroutine(rollingCoroutine);

        int currentValue = 0;
        int.TryParse(targetText.text, out currentValue);
        rollingCoroutine = StartCoroutine(RollNumber(currentValue, targetValue, duration));
    }

    private IEnumerator RollNumber(int from, int to, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);
            int value = Mathf.RoundToInt(Mathf.Lerp(from, to, t));
            targetText.text = value.ToString();
            yield return null;
        }
        targetText.text = to.ToString();
    }
}