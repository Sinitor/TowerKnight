using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Spine.Unity;

public class Player : MonoBehaviour
{ 

    [SerializeField] private int attack;
    [SerializeField] private TextMeshProUGUI pointText;

    private GameObject[] slots;
    private SkeletonAnimation anim;
    private Camera cam;
    private Vector2 defaultPos;

    private bool isEnemy = false;
    private bool isFight = false;
    private void Start()
    {
        cam = Camera.main;
        slots = GameObject.FindGameObjectsWithTag("Slot");
        pointText.text = "" + attack;
        defaultPos = transform.position;
        anim = GetComponent<SkeletonAnimation>(); 
    }
    private void OnMouseDrag()
    {
        if (isFight == false)
        {
            isEnemy = false;
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            float xPos = mousePosition.x;
            float yPos = mousePosition.y;
            transform.position = mousePosition;
        }
    }
    private void OnMouseUp()
    {
        float shortestDistance = Mathf.Infinity;
        Transform nearestBlock = null; 

        foreach (GameObject block in slots)
        {
            float distance = Vector2.Distance(transform.position, block.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestBlock = block.transform;
            }
        }
        if (nearestBlock != null && shortestDistance < 1)
        {
            transform.position = nearestBlock.position;
            isEnemy = true;
        }
        else
        {
            transform.position = defaultPos;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isEnemy == true)
        {
            isEnemy = false; 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (attack > enemy.attack && isFight == false)
            {
                StartCoroutine(Victory(enemy)); 
            }
            else if (attack < enemy.attack)
            {
                StartCoroutine(Lose(gameObject, enemy));
            }
        }
    }  
    private IEnumerator Victory(Enemy enemy)
    {
         isFight = true;
         anim.state.SetAnimation(0, "attack", true);
         enemy.anim.state.SetAnimation(0,"attack",true);
         Destroy(enemy.gameObject,2);
         yield return new WaitForSeconds(2);
         attack += enemy.attack;
         pointText.text = "" + attack;
         anim.state.SetAnimation(0, "idle", true);
         isFight = false;
    }
    private IEnumerator Lose(GameObject player, Enemy enemy)
    {
        isFight = true;
        anim.state.SetAnimation(0, "attack", true);
        enemy.anim.state.SetAnimation(0, "attack", true);
        yield return new WaitForSeconds(2);
        Destroy(player);
        enemy.anim.state.SetAnimation(0, "idle", true);
    } 
    public void RewardedAttack(int plusAttack)
    {
        attack = attack + plusAttack;
        pointText.text = "" + attack;
    }
}
