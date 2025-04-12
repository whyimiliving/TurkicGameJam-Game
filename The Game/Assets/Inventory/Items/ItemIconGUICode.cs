using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconGUICode : MonoBehaviour
{
    public TextMeshProUGUI amount;
    public RawImage rawImage;
    public ItemHolder itemHolder;

    public void SetPrefab(ItemHolder collectableItem)
    {
        amount.text = collectableItem.amount.ToString();
        rawImage.texture = collectableItem.itemSo.icon.texture;
        itemHolder = collectableItem;
    }

    public void ShowMe()
    {
        ItemGUICode.instance.SetPrefab(itemHolder);
    }
}
