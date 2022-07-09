using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private InterstitialAds InterstitialAds;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
    public void RePlay()
    {
        InterstitialAds.ShowAd();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
