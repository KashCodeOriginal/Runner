using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitialization : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool _testMode = true;
    private const string ANDROID_GAME_ID = "4932705";
    private const string IOS_GAME_ID = "4932704";
    private string _gameID;

    private void Awake()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
        _gameID = Application.platform == RuntimePlatform.Android ? ANDROID_GAME_ID : IOS_GAME_ID;
        Advertisement.Initialize(_gameID, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity ads successfully loaded");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Unity ads loading failed");
    }
}
