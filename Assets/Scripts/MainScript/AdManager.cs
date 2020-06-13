using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    //string App_ID="ca-app-pub-8290710233235536~9063000714";
    string Banner_AD_ID = "ca-app-pub-8290710233235536/9927352215";
    string Interstitial_AD_ID = "ca-app-pub-8290710233235536/2595657101";
    string Video_AD_ID = "ca-app-pub-8290710233235536/8563327329";
    public static AdManager instance;
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    void Awake(){
        if (instance == null) {
            instance = this;
        } 
        RequestBanner();
    }

    void Start()
    {
       //MobileAds.Initialize(App_ID);  
       MobileAds.Initialize(initStatus => { });
       ShowBannerAD();
        // // Called when an ad request has successfully loaded.
        // rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // // Called when an ad request failed to load.
        // rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        //  // Called when the user should be rewarded for watching a video.
        // rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // // Called when the ad is closed.
        // rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
    }

    public void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(Banner_AD_ID, AdSize.Banner, AdPosition.Top);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        Debug.Log("............RequestBanner...............");
    }
    public void ShowBannerAD()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        Debug.Log("..............ShowBanner......................");
    }
    public void DestroyBanner(){
        if(this.bannerView!=null){
            this.bannerView.Destroy();
            Debug.Log("..............DestroyBanner......................");
        }
    }

    public void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_AD_ID);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
        Debug.Log("..............IntersititialRequest......................");
    }
    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            Debug.Log("..............IntersititialShow......................");
        }
    }
    public void NotShowIntersititialAd(){
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Destroy();
            Debug.Log("..............IntersititialDestroy......................");
        }
    }

    public void RequestRewardBasedVideo()
    {
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
         // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, Video_AD_ID);
        Debug.Log("..............RewardedRequest......................");
    }

    public void ShowVideoRewardAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
            Debug.Log("..............RewardedShow......................");
        }
    }
        // FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        // if (this.interstitial.IsLoaded())
        // {
        //     this.interstitial.Show();
        // }
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        // if (this.rewardBasedVideo.IsShowed())
        // {
        //    GameManager.instance.RewardedGame();
        // }
    }
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        RequestRewardBasedVideo();
        GameManager.instance.WatchAdsDisplayHandle();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        GameManager.instance.RewardedGame();
    }
    

    
}
