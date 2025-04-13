using UnityEngine;

public class SortingOrderByY : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Start()
    {
        SetOrder();
    }

    public void SetOrder()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
        }
    }
}
