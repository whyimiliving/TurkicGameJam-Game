using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager _inventoryManager;
    public List<ItemHolder> Cards;
    public Transform inventoryParent;
    public GameObject itemGuiPrefab;

    void Awake()
    {
        if (_inventoryManager == null)
        {
            _inventoryManager = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        GenerateInventory();
    }

    public void RemoveLestValueable()
    {
        ItemHolder lowestPowerCard = Cards
            .Where(holder => holder.itemSo != null) // safety check
            .OrderBy(holder => holder.itemSo.power)
            .FirstOrDefault();
        if (lowestPowerCard != null)
        {
            lowestPowerCard.amount--;
            if (lowestPowerCard.amount <= 0)
            {
                Cards.Remove(lowestPowerCard);
            }
        }
    }

    public void AddCards(ItemHolder[] itemHolders)
    {
        foreach (ItemHolder itemHolder in itemHolders)
        {
            AddCard(itemHolder);
        }
        GenerateInventory();
    }

    public void AddCard(ItemHolder holder)
    {
        var existingHolder = Cards.FirstOrDefault(c => c.itemSo == holder.itemSo);

        if (existingHolder != null)
        {
            existingHolder.amount += holder.amount;
        }
        else
        {
            Cards.Add(holder);
        }
    }

    public void GenerateInventory()
    {
        foreach (Transform child in inventoryParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < Cards.Count; i++)
        {
            SpawnItem(i);
        }
    }

    public void SpawnItem(int i)
    {
        GameObject newItem = Instantiate(itemGuiPrefab, inventoryParent);
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2((i * 100) + 60, -38);
        }
        ItemIconGUICode itemGUIIconCode = newItem.GetComponent<ItemIconGUICode>();
        if (itemGUIIconCode != null)
        {
            itemGUIIconCode.SetPrefab(Cards[i]);
        }
    }
}
