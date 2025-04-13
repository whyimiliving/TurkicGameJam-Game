using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class Hand : MonoBehaviour
{
    public static Hand _hand;
    public List<CardItem> cardsHand;
    public Transform handParent;
    public GameObject handCardGUIPrefab;
    public bool isAnyUsing;

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
        foreach (CardItem cardItem in itemHolders)
        {
            AddCard(cardItem);
            SpawnItem(cardItem);
        }
    }

    public void ClearHand()
    {
        cardsHand.Clear();
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
            SpawnItem(cardsHand[i]);
        }
    }

    public void SpawnItem(CardItem cardItem)
    {
        GameObject newItem = Instantiate(handCardGUIPrefab, handParent);
        HandCardGUI handCardGUI = newItem.GetComponent<HandCardGUI>();
        if (handCardGUI != null)
        {
            handCardGUI.SetPrefab(cardItem);
        }
    }
}
