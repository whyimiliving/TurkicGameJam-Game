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

    public void SetMe(CardItem _cardItem, EnemyDeck _enemyDeck)
    {
        cardItem = _cardItem;
        enemyDeck = _enemyDeck;
        rawImage.texture = cardItem.icon.texture;
        cardName.text = cardItem.itemName;
        Hp = cardItem.power;
        SetHpBar();
    }

    public void TakeDmg(float dmg)
    {
        Hp -= dmg;
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
