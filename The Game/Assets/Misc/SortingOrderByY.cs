using UnityEngine;

// From GPT with love
[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int lastOrder = int.MinValue;

    public float minY = -5f;
    public float maxY = 5f;

    private const int minOrder = -100;
    private const int maxOrder = 100;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        float y = transform.position.y;

        float t = Mathf.InverseLerp(maxY, minY, y);
        int newOrder = Mathf.RoundToInt(Mathf.Lerp(minOrder, maxOrder, t));

        if (newOrder != lastOrder)
        {
            spriteRenderer.sortingOrder = newOrder;
            lastOrder = newOrder;
        }
    }
}
