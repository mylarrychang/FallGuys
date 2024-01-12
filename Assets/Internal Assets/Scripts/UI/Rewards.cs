using UnityEngine;
using UnityEngine.UI;

public class Rewards : MonoBehaviour
{
    public Button rewardsButton;
    public Image buttonImageHolder;
    public Sprite grayButtonSprite;
    public Sprite greenButtonSprite;
    public Material grayTint;

    public GameObject checkMark;

    public void Start()
    {
        int rewardClaimed = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_REWARD_CLAIMED);

        // Already claimed the reward. Then disable the button and mark as collected...
        if(rewardClaimed > 0)
        {
            buttonImageHolder.sprite = grayButtonSprite;
            rewardsButton.interactable = false;
            buttonImageHolder.material = grayTint;
            checkMark.SetActive(true);
	    }
        else
        { 
            buttonImageHolder.sprite = greenButtonSprite;
            rewardsButton.interactable = true;
            buttonImageHolder.material = null;
            checkMark.SetActive(false);
	    }
    }

    public void Claim()
    { 
        buttonImageHolder.sprite = grayButtonSprite;
        rewardsButton.interactable = false;

        int lifeCount = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        lifeCount += 2;
        if (lifeCount > Constants.MAX_LIFE_COUNT) lifeCount = Constants.MAX_LIFE_COUNT;
        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_LIFE_COUNT, lifeCount);

        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_REWARD_CLAIMED, 1);
    }
}
