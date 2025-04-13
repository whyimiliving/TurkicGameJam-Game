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

    public void SetPrefab(CardItem _cardItem)
    {
        cardItem = _cardItem;
        rawImage.texture = _cardItem.icon.texture;
        powerText.text = cardItem.power.ToString();
    }

    public void UseMe()
    {
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
        allEnemyMonsters[0].TakeDmg(cardItem.power);
        allEnemyMonsters[0].TriggerShake();
        Destroy(a);
        Destroy(this.gameObject);
    }

    public void ChangeConditionMet()
    {
        conditionMet = true;
    }
}
