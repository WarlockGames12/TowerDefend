using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTroopsUI : MonoBehaviour
{

    public bool SelectTroopsUIs = false;
    public GameObject SelectCanvas;
    public CanvasGroup Panels;

    // Start is called before the first frame update
    void Start()
    {
        SelectCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && SelectTroopsUIs == false)
        {
            TroopsOn();
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown(KeyCode.Q) && SelectTroopsUIs == true){
            TroopsOff();
            Time.timeScale = 1f;
        }
    }

    void TroopsOn()
    {
        FadeIn();
        SelectCanvas.SetActive(true);
        SelectTroopsUIs = true;
    }
    void TroopsOff()
    {
        FadeOut();
        SelectCanvas.SetActive(false);
        SelectTroopsUIs = false;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(Panels, Panels.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(Panels, Panels.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1f)
    {
        float _timeStartedLerping = Time.unscaledTime;
        float timeSinceStarted = Time.unscaledTime - _timeStartedLerping;

        float PercentageCompleted = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.unscaledTime - _timeStartedLerping;
            PercentageCompleted = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, PercentageCompleted);
            cg.alpha = currentValue;

            if (PercentageCompleted >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        print("Done");
    }
}
