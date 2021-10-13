using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceIt : MonoBehaviour
{

    public GameObject CanonPrefab;
    private GameObject CanonPrefabs;
    public GameObject WizardPrefab;
    private GameObject WizardPrefabs;
    public GameObject[] Tiles;
    public GameObject Shop;
    public bool ShopisVisable = false;
    public bool CanPlaceObject = true;
    public CanvasGroup uiElement;
    public Vector3 direction;

    private GameObject selectedTile = null;

    private float timer = 0;

    void Start()
    {
        Shop.SetActive(false);
    }

    void Update()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
            CheckMouse();



       /* if (CanPlacePrefab())
        {
            Vector2 mousePos = Input.mousePosition;
            {
                if (hit.collider.tag == "Grass")
                {
                    Debug.Log("Hoi");
                    Transform objectHit = hit.transform;
                    FadeIn();
                    Shop.SetActive(true);
                    ShopisVisable = true;
                    Time.timeScale = 0f;
                    if (!CanPlaceObject)
                    {
                        Debug.Log("It has already been placed");
                    }
                    //Display the name of the parent of the object hit.
                    Debug.Log(objectHit.parent.name);
                }
                
            }

        }*/


    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0) && !ShopisVisable)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, 10.0f);

            if (hit.collider == null)
                return;

            if (hit.collider.tag == "Grass")
            {
                if (!hit.collider.gameObject.GetComponent<CanYouPlaceIt>().Occupied())
                {
                    selectedTile = hit.collider.gameObject;
                    ShopisVisable = true;
                    Shop.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            else return;
        }
    }

    private bool CanPlacePrefab()
    {
        return CanonPrefabs == null;
    }


    void OnMouseUp()
    {

    }

    public void CanonPrefabs1()
    {
        CanonPrefabs = Instantiate(CanonPrefab, selectedTile.transform.position, Quaternion.identity);
        selectedTile.GetComponent<CanYouPlaceIt>().Turret = CanonPrefabs;
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        timer = .1f;
        CanPlaceObject = false;
        ShopisVisable = false;
        Shop.SetActive(false);
        Time.timeScale = 1f;
    }

    public void WizardPrefabs1()
    {
        WizardPrefabs = (GameObject)Instantiate(WizardPrefab, selectedTile.transform.position, Quaternion.identity);
        selectedTile.GetComponent<CanYouPlaceIt>().Turret = WizardPrefabs;
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        timer = .1f;
        CanPlaceObject = false;
        ShopisVisable = false;
        Shop.SetActive(false);
        Time.timeScale = 1f;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
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
