using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemGUICode : MonoBehaviour
{
    public static ItemGUICode instance;
    public GameObject detailedItem;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemPower;
    public TextMeshProUGUI amount;
    public RawImage rawImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        detailedItem.SetActive(false);
    }

    public void SetPrefab(ItemHolder collectableItem)
    {
        itemName.text = collectableItem.itemSo.itemName.ToString();
        itemDescription.text = collectableItem.itemSo.description.ToString();
        itemPower.text = collectableItem.itemSo.power.ToString();
        amount.text = collectableItem.amount.ToString();
        rawImage.texture = collectableItem.itemSo.icon.texture;

        detailedItem.SetActive(true);
    }

    public void ClosePrefab()
    {
        detailedItem.SetActive(false);
    }
}
