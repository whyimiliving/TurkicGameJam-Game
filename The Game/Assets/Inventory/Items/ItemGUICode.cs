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
    public GameObject[] tkm;

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

        foreach (var item in tkm)
        {
            item.SetActive(false);
        }
        switch (collectableItem.itemSo.cardStatus)
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

        detailedItem.SetActive(true);
    }

    public void ClosePrefab()
    {
        detailedItem.SetActive(false);
    }
}
