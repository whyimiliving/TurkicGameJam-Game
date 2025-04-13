using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMonster : MonoBehaviour
{
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI hpText;
    public EnemyDeck enemyDeck;
    public CardItem cardItem;
    public RawImage rawImage;
    public float Hp;
    public GameObject[] tkm;

    public void SetMe(CardItem _cardItem, EnemyDeck _enemyDeck)
    {
        cardItem = _cardItem;
        enemyDeck = _enemyDeck;
        rawImage.texture = cardItem.icon.texture;
        cardName.text = cardItem.itemName;
        Hp = cardItem.power;
        SetHpBar();

        foreach (var item in tkm)
        {
            item.SetActive(false);
        }
        switch (_cardItem.cardStatus)
        {
            case CardStatus.Tas:
                tkm[0].SetActive(true);
                break;
            case CardStatus.Kagit:
                tkm[1].SetActive(true);
                break;
            case CardStatus.Makas:
                tkm[2].SetActive(true);
                break;
        }
    }

    public void TakeDmg(float dmg, CardStatus cardStatus)
    {
        if (cardItem.cardStatus == CardStatus.Makas)
        {
            if (cardStatus == CardStatus.Makas)
            {
                Hp -= dmg;
            }
            if (cardStatus == CardStatus.Tas)
            {
                Hp -= dmg * 1.5f;
            }
            if (cardStatus == CardStatus.Kagit)
            {
                Hp -= dmg * 0.75f;
            }
        }
        if (cardItem.cardStatus == CardStatus.Kagit)
        {
            if (cardStatus == CardStatus.Kagit)
            {
                Hp -= dmg;
            }
            if (cardStatus == CardStatus.Makas)
            {
                Hp -= dmg * 1.5f;
            }
            if (cardStatus == CardStatus.Tas)
            {
                Hp -= dmg * 0.75f;
            }
        }
        if (cardItem.cardStatus == CardStatus.Tas)
        {
            if (cardStatus == CardStatus.Tas)
            {
                Hp -= dmg;
            }
            if (cardStatus == CardStatus.Kagit)
            {
                Hp -= dmg * 1.5f;
            }
            if (cardStatus == CardStatus.Makas)
            {
                Hp -= dmg * 0.75f;
            }
        }

        if (Hp <= 0)
        {
            Die();
        }
        SetHpBar();
    }

    public void Die()
    {
        enemyDeck.NextEnemyCard();
        Destroy(this.gameObject);
    }

    void SetHpBar()
    {
        hpText.text = Hp.ToString();
    }

#region shake
    public float shakeAmount = 10f;
    public float shakeDuration = 0.7f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float timeElapsed = 0f;

        while (timeElapsed < shakeDuration)
        {
            transform.localPosition = originalPosition + (Vector3)(Random.insideUnitCircle * shakeAmount);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
#endregion
}
