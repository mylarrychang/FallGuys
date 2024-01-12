using Ricimi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlUi : MonoBehaviour
{
    public List<Image> slides = default;
    public GameObject slideHolder = default;
    public GameObject spin = default;

    public Button play = default;
    public Image playButtonImage = default;
    public Image grayButtonImage = default;

    public float switchDuration = 0.5f;
    public int mapIndex = 0;

    private int currentSlide = 0;

    public void Start()
    {
        currentSlide = 2 * slides.Count;
        slideHolder.SetActive(false);
        spin.SetActive(true);
        play.interactable = true;

        mapIndex = Random.Range(0, slides.Count);
        Debug.Log("MapIndex: " + mapIndex);
    }

    public void StartGame()
    {
        int lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        if (lifeCount > 0)
        {
            slideHolder.SetActive(true);
            spin.SetActive(false);
            play.interactable = false;
            playButtonImage.sprite = grayButtonImage.sprite;

            StartCoroutine(WaitToNextSlide());
        }
        else
        {
            gameObject.GetComponent<PopupOpener>().OpenPopup();
        }
    }

    IEnumerator WaitToNextSlide()
    {
        while (currentSlide >= mapIndex)
        {
            slideHolder.GetComponent<Image>().sprite = slides[currentSlide % slides.Count].sprite;
            if (currentSlide-- == mapIndex)
            { 
                // wait 2 more seconds for the last show...
                yield return new WaitForSeconds(switchDuration + 2);
	        }
            else
            { 
                yield return new WaitForSeconds(switchDuration);
	        }
	    }

        SceneManager.LoadScene(mapIndex + 1, LoadSceneMode.Single);
    }
}
