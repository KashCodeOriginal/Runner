using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private const string ANDROID_AD_ID = "Interstitial_Android";
    private const string IOS_AD_ID = "Interstitial_iOS";

    private string _adID;

    private void Awake()
    {
        _adID = Application.platform == RuntimePlatform.Android ? ANDROID_AD_ID : IOS_AD_ID;
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

    public void OnUnityAdsAdLoaded(string placementId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string placementId) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }
}
