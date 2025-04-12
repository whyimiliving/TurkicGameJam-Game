using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Card")]
public class CardItem : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int power;
}
