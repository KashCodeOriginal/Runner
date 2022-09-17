using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button _showingAdsButton;

    [SerializeField] private Player _player;
    
    private const string ANDROID_AD_ID = "Rewarded_Android";
    private const string IOS_AD_ID = "Rewarded_iOS";

    private string _adID;
    
    private void Awake()
    {
        _adID = Application.platform == RuntimePlatform.Android ? ANDROID_AD_ID : IOS_AD_ID;
    }
    private void Start()
    {
        LoadAd();
    }
    public void LoadAd()
    {
        Debug.Log("Loading ad: " + _adID);
        
        Advertisement.Load(_adID, this);
    }
    
    public void ShowAd()
    {
        Debug.Log("Showing ad: " + _adID);

        Advertisement.Show(_adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == _adID)
        {
            _showingAdsButton.onClick.AddListener(ShowAd);
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _adID && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            _player.AddCoin(20, true);
        }
    }

    private void OnDestroy()
    {
        _showingAdsButton.onClick.RemoveAllListeners();
    }
}
