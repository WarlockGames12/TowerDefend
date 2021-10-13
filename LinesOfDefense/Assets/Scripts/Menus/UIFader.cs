using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{

    public CanvasGroup uiElement;


    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end , float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;

        float PercentageCompleted = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            PercentageCompleted = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, PercentageCompleted);
            cg.alpha = currentValue;

            if (PercentageCompleted >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        print("Done");
    }
}
