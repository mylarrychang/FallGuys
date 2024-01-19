using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpinAable : MonoBehaviour
{
    // This animation curve drives the spin wheel motion.
    public AnimationCurve AnimationCurve;

    public Button spinButton;

    public Image grayImage;
    public Image blueImage;
    public Image imageHolder;

    private float time = 3f;

    private int angel = 0;
    private int realIndex = 0;

    private bool m_spinning = false;

    public void Start()
    {
        /*
        PlayerPrefs.SetInt(
            Constants.PLAYER_PREFAB_TOTAL_CROWNS,
            100);
        */
    }

    public void Update()
    {
        CheckCrownCount();
    }

    public void Spin()
    {
        if (!m_spinning)
        {
            InactiveButton();
            DoRewards();
            StartCoroutine(DoSpin());
        }
    }

    private IEnumerator DoSpin()
    {
        m_spinning = true;
        var timer = 0.0f;
        var startAngle = transform.eulerAngles.z;

        while (timer < time)
        {
            var angle = AnimationCurve.Evaluate(timer / time) * angel;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.eulerAngles = new Vector3(0.0f, 0.0f, angel + startAngle);
        m_spinning = false;

        // Give Rewards
        switch (realIndex)
        {
            case 0:
                Debug.Log("Adding hearts: 1");
                // 1 heart
                PlayerPrefs.SetInt(
                    Constants.PLAYER_PREFAB_LIFE_COUNT,
                    Mathf.Min(5, PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT) + 1));
                break;
            case 2:
                Debug.Log("Adding hearts: 2");
                // 2 hearts
                PlayerPrefs.SetInt(
                    Constants.PLAYER_PREFAB_LIFE_COUNT,
                    Mathf.Min(5, PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT) + 2));
                break;
            case 4:
                Debug.Log("Adding crowns: 10");
                // 10 crowns
                PlayerPrefs.SetInt(
                    Constants.PLAYER_PREFAB_TOTAL_CROWNS,
                    PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS) + 10);
                break;
            case 6:
                Debug.Log("Adding crowns: 5");
                // 5 crowns
                PlayerPrefs.SetInt(
                    Constants.PLAYER_PREFAB_TOTAL_CROWNS,
                    PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS) + 5);
                break;
            default:
                break;
        }

        ActiveButton();
    }

    private void DoRewards()
    {
        // Cost 5 crowns
        PlayerPrefs.SetInt(
            Constants.PLAYER_PREFAB_TOTAL_CROWNS,
            PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS) - Constants.SPIN_COST_CROWNS);

        // 0: 1 heart
        // 1: empty
        // 2: 2 hearts
        // 3: empty
        // 4: 10 crowns
        // 5: empty
        // 6: 5 crowns
        // 7: empty
        int index = Random.Range(0, 8);
        angel = (index * 45) + 360;
        // Debug.Log("Angel: " + angel);
        realIndex = (index + realIndex) % 8;
        // Debug.Log("spin index is: " + index);
        Debug.Log("spin real index is: " + realIndex);
    }

    private void InactiveButton()
    {
        spinButton.interactable = false;
        imageHolder.sprite = grayImage.sprite;
    }

    private void ActiveButton()
    {
        spinButton.interactable = true;
        imageHolder.sprite = blueImage.sprite;
    }

    private void CheckCrownCount()
    { 
        // Cost 5 crowns;
        int totalCrowns = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_TOTAL_CROWNS);
        if (totalCrowns < Constants.SPIN_COST_CROWNS)
        {
            InactiveButton();
        }
        else
        {
            ActiveButton();
        }
    }
}
