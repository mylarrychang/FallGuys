using Ricimi;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            int curLife = MinusLife();
            if (curLife == 0)
            {
                Debug.Log("No life left. Open popup window to watch Ads...");
                gameObject.GetComponent<PopupOpener>().OpenPopup();
            }

			col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
		}
	}


    private int MinusLife()
    {
        int curLife = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_LIFE_COUNT);
        if (--curLife < 0) curLife = 0;

        PlayerPrefs.SetInt(Constants.PLAYER_PREFAB_LIFE_COUNT, curLife);

        return curLife;
    }
}
