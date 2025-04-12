using System.Collections;
using System.Threading;
using UnityEngine;

public class SnakeMain : MonoBehaviour
{
    public Animator animator;
    public bool conditionMet = false;
    public GameObject poisonPrefab;
    public Transform snakeHead;

    void Start()
    {
        StartCoroutine(StartFight());
    }

    void Update()
    {

    }

    IEnumerator StartFight()
    {
        Debug.Log("Bişiler Söyle");
        yield return new WaitForSeconds(3);
        //yield return new WaitUntil(() => conditionMet);
        Debug.Log("start");
        ChoseRandomAttack();
    }

    void ChoseRandomAttack()
    {
        var attackNum = Random.Range(0, 1);
        switch (attackNum)
        {
            case 0:
                StartCoroutine(Attack());
                break;
        }
    }


    IEnumerator Attack()
    {
        Debug.Log("Poison başlado");
        animator.SetTrigger("Poison");
        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;
        Debug.Log("Poison bitti");

    }

    public void CreatePoisonFromHead()
    {
        var poison = Instantiate(poisonPrefab, snakeHead.position, snakeHead.rotation);
    }
}