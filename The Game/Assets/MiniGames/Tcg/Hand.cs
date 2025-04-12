using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class Hand : MonoBehaviour
{
    public static Hand _hand;
    public List<CardItem> cardsHand;
    public Transform handParent;
    public GameObject handCardGUIPrefab;

    private void Awake()
    {
        if (_hand == null)
        {
            _hand = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        GenerateHand();
    }

    public void AddCards(CardItem[] itemHolders)
    {
        foreach (CardItem itemHolder in itemHolders)
        {
            AddCard(itemHolder);
        }
        GenerateHand();
    }

    public void AddCard(CardItem cardItem)
    {
        cardsHand.Add(cardItem);
    }

    public void RemoveFromDeck(int index)
    {
        cardsHand.RemoveAt(index);
    }

    public void GenerateHand()
    {
        foreach (Transform child in handParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < cardsHand.Count; i++)
        {
            SpawnItem(i);
        }
    }

    public void SpawnItem(int i)
    {
        GameObject newItem = Instantiate(handCardGUIPrefab, handParent);
        HandCardGUI handCardGUI = newItem.GetComponent<HandCardGUI>();
        if (handCardGUI != null)
        {
            handCardGUI.SetPrefab(cardsHand[i]);
        }
    }
}
