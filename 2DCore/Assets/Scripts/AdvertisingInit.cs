using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisingInit : MonoBehaviour,IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameID = "4833509"; 
    [SerializeField] private string iosGameID = "4833508";
    [SerializeField] private bool testMode = true;
    private string gameID;

    private void Awake()
    {
        InitAds();
    } 

    public void InitAds()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iosGameID : androidGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Succes");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Wrong");
    }
}
