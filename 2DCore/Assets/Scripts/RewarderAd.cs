using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewarderAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button buttonShowAd;
    [SerializeField] private string androidId = "Rewarded_Android";
    [SerializeField] private string iosId = "Rewarded_iOS";
    private string adId;
    [SerializeField] private Player player;

    private void Awake()
    {
        adId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosId : androidId;
    }
    private void Start()
    {
        LoadAd();
    }
     
    public void LoadAd()
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
        if (placementId.Equals(adId))
        {
            buttonShowAd.onClick.AddListener(ShowAd);
        }
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
        if (placementId.Equals(adId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            player.RewardedAttack(10);
        }
    }
}
