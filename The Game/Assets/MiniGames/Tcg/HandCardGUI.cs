using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandCardGUI : MonoBehaviour, IAnimStarter
{
    public RawImage rawImage;
    public TextMeshProUGUI powerText;
    public CardItem cardItem;
    public GameObject hitAnimObj;
    public GameObject innerCard;
    private bool conditionMet;
    private bool usedCard;
    public GameObject[] tkm;

    public void SetPrefab(CardItem _cardItem)
    {
        cardItem = _cardItem;
        rawImage.texture = _cardItem.icon.texture;
        powerText.text = cardItem.power.ToString();

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

    public void UseMe()
    {
        EnemyMonster[] allEnemyMonsters = FindObjectsOfType<EnemyMonster>();
        if (usedCard || Hand._hand.isAnyUsing || allEnemyMonsters.Length <= 0)
        {
            return;
        }
        usedCard = true;
        Hand._hand.isAnyUsing = true;
        innerCard.GetComponent<RectTransform>().Translate(Vector3.up * 40);
        Transform parent = this.gameObject.transform.parent;
        int index = this.gameObject.transform.GetSiblingIndex();
        Hand._hand.RemoveFromDeck(index);

        StartCoroutine(DestroyAnim());
    }

    IEnumerator DestroyAnim()
    {
        var a = Instantiate(hitAnimObj, transform.parent.transform.parent);
        a.GetComponent<HitAnimCode>().SetPrefab(cardItem, this);
        a.transform.SetAsFirstSibling();

        yield return new WaitUntil(() => conditionMet);
        conditionMet = false;

        EnemyMonster[] allEnemyMonsters = FindObjectsOfType<EnemyMonster>();
        allEnemyMonsters[0].TakeDmg(cardItem.power, cardItem.cardStatus);
        allEnemyMonsters[0].TriggerShake();
        Destroy(a);
        Hand._hand.isAnyUsing = false;
        Destroy(this.gameObject);
    }

    public void ChangeConditionMet()
    {
        conditionMet = true;
    }
}
