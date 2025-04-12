using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandCardGUI : MonoBehaviour
{
    public RawImage rawImage;
    public CardItem cardItem;

    public void SetPrefab(CardItem _cardItem)
    {
        cardItem = _cardItem;
        rawImage.texture = _cardItem.icon.texture;

    }

    public void UseMe()
    {
        Transform parent = this.gameObject.transform.parent;
        int index = this.gameObject.transform.GetSiblingIndex();
        Hand._hand.RemoveFromDeck(index);

        EnemyMonster[] allEnemyMonsters = FindObjectsOfType<EnemyMonster>();
        allEnemyMonsters[0].TakeDmg(cardItem.power);
        DestroyAnim();
    }

    public void DestroyAnim()
    {
        Destroy(this.gameObject);
    }
}
