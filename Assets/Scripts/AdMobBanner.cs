using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobBanner : MonoBehaviour
{
    private BannerView bannerView;

    private void Awake()
    {
        if (FindObjectsOfType<AdMobBanner>().Length > 1)
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
        MobileAds.Initialize(initStatus => { });

        RequestBanner();
    }

    public void RequestBanner()
    {
    
        string adUnitId = "ca-app-pub-4015467829433215/3005549128";

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    private void OnDestroy()
    {
         bannerView?.Destroy();
    }


}
