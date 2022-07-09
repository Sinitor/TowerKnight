using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform boss;
    [SerializeField] private GameObject panel;
    private bool isBool = false;

    private void Update()
    {
        if (boss == null && isBool == false)
        {
            isBool = true;
            panel.SetActive(true);
        }
    }
}
