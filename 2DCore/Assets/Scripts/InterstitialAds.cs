using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] private string androidId = "Interstitial_Android";
    [SerializeField] private string iosId = "Interstitial_iOS";
    private string adId;

    private void Awake()
    {
        adId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosId : androidId;
        LoadAd();
    }  
    private void LoadAd()
    {
        Debug.Log("Loading AD");
        Advertisement.Load(adId, this);
    } 
    public void ShowAd()
    {
        Debug.Log("Show AD");
        Advertisement.Show(adId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Loaded" + adId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Start" + adId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }
}
