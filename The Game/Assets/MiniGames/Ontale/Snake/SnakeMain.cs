using System.Collections;
using System.Threading;
using UnityEngine;

public class SnakeMain : MonoBehaviour, IAnimStarter
{
    public Animator animator;
    public bool conditionMet = false;
    public GameObject poisonPrefab;
    public Transform snakeHead;
    public Transform snakeHead2;
    public Transform[] snakeFangs;
    public GameObject[] obstacles;
    public int currentLvl;
    public SnakeHp snakeHp;

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

    IEnumerator SayRandom()
    {
        if (obstacles.Length > currentLvl && obstacles[currentLvl])
        {
            obstacles[currentLvl]?.SetActive(true);
            currentLvl++;
        }

        if (snakeHp.currentHp <= 0)
        {
            Debug.Log("kaybettim gg");
            yield return new WaitForSeconds(5);
            MiniGameManager._miniGameManager.CloseMinigame(GameNames.OntaleScene);
        }
        else
        {
            Debug.Log("Başka Bişiler Söyle");
            yield return new WaitForSeconds(5);
            ChoseRandomAttack();
        }
    }

    void ChoseRandomAttack()
    {
        var attackNum = Random.Range(0, 3);
        switch (attackNum)
        {
            case 0:
                StartCoroutine(Attack());
                break;
            case 1:
                StartCoroutine(AttackBite());
                break;
            case 2:
                StartCoroutine(AttackHard());
                break;
        }
    }

    IEnumerator Attack()
    {
        animator.SetTrigger("Poison");
        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;
        snakeHp.TakeDmg(1);
        StartCoroutine(SayRandom());
    }

    IEnumerator AttackBite()
    {
        animator.SetTrigger("Bite");
        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;
        snakeHp.TakeDmg(1);
        StartCoroutine(SayRandom());
    }

    IEnumerator AttackHard()
    {
        animator.SetTrigger("PoisonHard");
        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;
        snakeHp.TakeDmg(2);
        StartCoroutine(SayRandom());
    }

    public void CreatePoisonFromHead()
    {
        var poison = Instantiate(poisonPrefab, snakeHead.position, snakeHead.rotation, this.gameObject.transform);
    }
    public void CreatePoisonFromHead2()
    {
        var poison = Instantiate(poisonPrefab, snakeHead2.position, snakeHead2.rotation, this.gameObject.transform);
    }

    public void CreatePoisonFromFangs()
    {
        foreach (Transform t in snakeFangs)
        {
            var poison = Instantiate(poisonPrefab, t.position, t.rotation, this.gameObject.transform);
        }
    }

    public void ChangeConditionMet()
    {
        conditionMet = true;
    }
}