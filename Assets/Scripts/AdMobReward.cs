using Assets.Scripts;
using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdMobReward : MonoBehaviour
{
    [SerializeField] GameObject rewardAnim;
    public RewardedAd rewardedAd;
    public int counter = 5;

    private void Awake()
    {
        if (FindObjectsOfType<AdMobReward>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        LoadReward();
    }

    public void LoadReward()
    {

        string adUnitId = "ca-app-pub-4015467829433215/8941252145";

        rewardedAd = new RewardedAd(adUnitId);

        rewardedAd.OnAdClosed += HandleOnAdClosed;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);        
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    private void HandleOnAdClosed(object sender, EventArgs args)
    {       
        LoadReward();
        Button watchAdButton = FindObjectOfType<GameOver>().watchAdButton;
        watchAdButton.interactable = false;
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        int amount = 30;
        SaveObject saveObject = SaveSystem.GetSaveObject();

        saveObject.totalGoldAmount += amount;
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);

        Button watchAdButton = FindObjectOfType<GameOver>().watchAdButton;

        Instantiate(rewardAnim, watchAdButton.transform);
    }
}
