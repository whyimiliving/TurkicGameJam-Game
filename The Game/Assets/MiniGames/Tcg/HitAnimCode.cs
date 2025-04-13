using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HitAnimCode : MonoBehaviour, IAnimStarter
{
    public RawImage rawImage;
    public HandCardGUI handCardGUI;

    public void SetPrefab(CardItem _cardItem, HandCardGUI _handCardGUI)
    {
        rawImage.texture = _cardItem.icon.texture;
        handCardGUI = _handCardGUI;
    }

    public void ChangeConditionMet()
    {
        handCardGUI.ChangeConditionMet();
    }
}
