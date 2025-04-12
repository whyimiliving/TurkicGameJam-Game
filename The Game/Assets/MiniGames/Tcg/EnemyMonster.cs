using System.Collections.Generic;
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
}
