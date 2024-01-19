using UnityEngine;

public class BgmControl : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    // Update is called once per frame
    void Update()
    {
        // 0 means enabled, 1 means disabled
        int enableBgm = PlayerPrefs.GetInt(Constants.PLAYER_PREFAB_ENABLE_BGM);

        Debug.Log("Enabled BGM: " + enableBgm);

        bgmAudioSource.enabled = (enableBgm == 1);
    }
}

