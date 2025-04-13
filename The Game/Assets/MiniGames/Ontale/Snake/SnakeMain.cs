using System.Collections;
using System.Threading;
using TMPro;
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

    IEnumerator StartFight()
    {
        animator.SetTrigger("Talk");
        StartCoroutine(ShowTextOneByOne(strings[1]));
        yield return new WaitForSeconds(5);
        ChoseRandomAttack();
    }

    IEnumerator SayRandom()
    {
        animator.SetTrigger("Talk");
        yield return new WaitForSeconds(2);
        if (obstacles.Length > currentLvl && obstacles[currentLvl])
        {
            obstacles[currentLvl]?.SetActive(true);
            currentLvl++;
        }

        if (snakeHp.currentHp <= 0)
        {
            StartCoroutine(ShowTextOneByOne(strings[0]));
            yield return new WaitForSeconds(7);
            MiniGameManager._miniGameManager.CloseMinigame(GameNames.OntaleScene, true);
        }
        else
        {
            StartCoroutine(ShowTextOneByOne(strings[Random.Range(2, strings.Length)]));
            yield return new WaitForSeconds(4);
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
        StartShake();
        StartCoroutine(SayRandom());
    }

    IEnumerator AttackBite()
    {
        animator.SetTrigger("Bite");
        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;
        snakeHp.TakeDmg(1);
        StartShake();
        StartCoroutine(SayRandom());
    }

    IEnumerator AttackHard()
    {
        animator.SetTrigger("PoisonHard");
        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;
        snakeHp.TakeDmg(2);
        StartShake();
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

#region shake
    public float shakeDuration = 1.5f;
    public float shakeMagnitude = 0.05f;

    private Vector3 originalPosition;

    void OnEnable()
    {
        originalPosition = transform.localPosition;
    }

    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
    #endregion

#region Chat

    public TextMeshProUGUI chatTmp;
    public float typingSpeed = 0.15f; 
    public string[] strings;

    IEnumerator ShowTextOneByOne(string fullText)
    {
        chatTmp.text = "";
        foreach (char c in fullText)
        {
            chatTmp.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    #endregion
}