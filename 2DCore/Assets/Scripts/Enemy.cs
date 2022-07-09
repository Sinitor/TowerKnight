using UnityEngine;
using TMPro;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;
    public int attack;
    public SkeletonAnimation anim;
    
    private void Start()
    {
        pointText.text = "" + attack;
    } 
}
