using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    public bool GamePaused = false;
    public GameObject pauseMenuUI;
    public AudioSource PauseGame;
    public CanvasGroup uiElement;



    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && GamePaused == true)
        {
            Resume();
            Time.timeScale = 1f;

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && GamePaused == false)
        {
            PauseGame1();
            Time.timeScale = 0f;
        }
    }

    void Resume()
    {
        FadeOut();
        pauseMenuUI.SetActive(false);
        GamePaused = false;
    }

    void PauseGame1()
    {
        FadeIn();
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
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
