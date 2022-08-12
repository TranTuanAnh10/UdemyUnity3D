using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Admob : Singleton<Admob>
{
    [Header("Admob Ad Units :")]
    // Test App Id = "ca-app-pub-3940256099942544~3347511713";
    [SerializeField] [TextArea(1, 2)] string idBanner = "ca-app-pub-3940256099942544/6300978111";
    [SerializeField] [TextArea(1, 2)] string idInterstitial = "ca-app-pub-3940256099942544/1033173712";
    [SerializeField] [TextArea(1, 2)] string idReward = "ca-app-pub-3940256099942544/5224354917";

    [Header("Toggle Admob Ads :")]
    [SerializeField] private bool bannerAdEnabled = true;
    [SerializeField] private bool interstitialAdEnabled = true;
    [SerializeField] private bool rewardedAdEnabled = true;

    [HideInInspector] public BannerView AdBanner;
    [HideInInspector] public InterstitialAd AdInterstitial;
    [HideInInspector] public RewardedAd AdReward;

    bool _firstInit = false;

    protected override void Awake()
    {
        base.Awake();

        // show banner every scene loaded
        SceneManager.sceneLoaded += (Scene s, LoadSceneMode lsm) => { if (_firstInit) ShowBanner(); };
    }

    private void Start()
    {
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
                .SetTagForChildDirectedTreatment(TagForChildDirectedTreatment.Unspecified)
                .build();

        MobileAds.Initialize(initstatus => {
            MobileAdsEventExecutor.ExecuteInUpdate(() => {
                ShowBanner();
                RequestRewardAd();
                RequestInterstitialAd();

                _firstInit = true;
            });
        });
    }

    private void OnDestroy()
    {
        DestroyBannerAd();
        DestroyInterstitialAd();
    }

    public void Destroy() => Destroy(gameObject);

    public bool IsRewardAdLoaded()
    {
        if (rewardedAdEnabled && AdReward.IsLoaded())
            return true;
        else
            return false;
    }

    AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
           .TagForChildDirectedTreatment(false)
           .AddExtra("npa", PlayerPrefs.GetInt("npa", 1).ToString())
           .Build();
    }

    #region Banner Ad ------------------------------------------------------------------------------
    public void ShowBanner()
    {
        if (!bannerAdEnabled) return;

        DestroyBannerAd();

        AdSize adSize = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        AdBanner = new BannerView(idBanner, adSize, AdPosition.Bottom);

        AdBanner.LoadAd(CreateAdRequest());
    }

    public void DestroyBannerAd()
    {
        if (AdBanner != null)
            AdBanner.Destroy();
    }
    #endregion

    #region Interstitial Ad ------------------------------------------------------------------------
    public void RequestInterstitialAd()
    {
        AdInterstitial = new InterstitialAd(idInterstitial);

        AdInterstitial.OnAdClosed += HandleInterstitialAdClosed;

        AdInterstitial.LoadAd(CreateAdRequest());
    }

    public void ShowInterstitialAd()
    {
        if (!interstitialAdEnabled) return;

        if (AdInterstitial.IsLoaded())
            AdInterstitial.Show();
    }

    public void DestroyInterstitialAd()
    {
        if (AdInterstitial != null)
            AdInterstitial.Destroy();
    }
    #endregion

    #region Rewarded Ad ----------------------------------------------------------------------------
    public void RequestRewardAd()
    {
        AdReward = new RewardedAd(idReward);

        AdReward.OnAdClosed += HandleOnRewardedAdClosed;
        AdReward.OnUserEarnedReward += HandleOnRewardedAdWatched;

        AdReward.LoadAd(CreateAdRequest());
    }

    public void ShowRewardAd()
    {
        if (!rewardedAdEnabled) return;

        if (AdReward.IsLoaded())
            AdReward.Show();
    }
    #endregion

    #region Event Handler
    private void HandleInterstitialAdClosed(object sender, EventArgs e)
    {
        DestroyInterstitialAd();
        RequestInterstitialAd();
    }

    private void HandleOnRewardedAdClosed(object sender, EventArgs e)
    {
        RequestRewardAd();
    }

    private void HandleOnRewardedAdWatched(object sender, Reward e)
    {
        print("rewarded watched");
        FindObjectOfType<GameManager>().RevivePlayer();
    }
    #endregion
}
