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

    }
}
