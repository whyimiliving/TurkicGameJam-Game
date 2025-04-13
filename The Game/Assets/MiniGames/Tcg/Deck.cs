using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class Deck : MonoBehaviour
{
    public List<CardItem> deckCards;
    public GameObject SfxDrawCard;
    public TextMeshProUGUI cardLeft;

    private void Start()
    {
        SetDeck(InventoryManager._inventoryManager.Cards);
    }

    public void SetDeck(List<ItemHolder> cards)
    {
        foreach (ItemHolder item in cards)
        {
            for (int i = 0; i < item.amount; i++)
            {
                AddToDeck(item.itemSo);
            }
        }
        Shuffle(deckCards);
        UpdateGui();
    }

    void UpdateGui()
    {
        cardLeft.text = deckCards.Count.ToString();
    }

    public void AddToDeck(CardItem cardItem)
    {
        deckCards.Add(cardItem);
    }

    public void RemoveFromDeck(int index)
    {
        deckCards.RemoveAt(index);
        UpdateGui();
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void DrawTop(int numberr)
    {
        StartCoroutine(DrawOneByOne(numberr));
    }

    IEnumerator DrawOneByOne(int numberr)
    {
        for (int i = 0; i < numberr; i++)
        {
            if (deckCards.Count <= 0)
            {
                yield return null;
            }

            Instantiate(SfxDrawCard);
            CardItem topCard = deckCards[0];
            Hand._hand.AddCards(new CardItem[] { topCard });
            RemoveFromDeck(0);
            yield return new WaitForSeconds(0.4f);
        }
    }
}
