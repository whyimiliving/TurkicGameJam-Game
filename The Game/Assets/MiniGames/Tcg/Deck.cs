using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<CardItem> deckCards;

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
    }

    public void AddToDeck(CardItem cardItem)
    {
        deckCards.Add(cardItem);
    }

    public void RemoveFromDeck(int index)
    {
        deckCards.RemoveAt(index);
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
        for (int i = 0; i < numberr; i++)
        {
            if (deckCards.Count <= 0)
            {
                return;
            }

            CardItem topCard = deckCards[0];
            Hand._hand.AddCards(new CardItem[] { topCard });
            RemoveFromDeck(0);
        }
    }
}
