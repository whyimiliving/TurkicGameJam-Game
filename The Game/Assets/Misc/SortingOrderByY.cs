using UnityEngine;

public class SortingOrderByY : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = FindFirstObjectByType<PlayerMovement>().transform;
    }

    void LateUpdate()
    {
        DoYour();
    }

    void DoYour()
    {
        if (spriteRenderer != null)
        {
            if (playerTransform.position.y > transform.position.y)
            {
                spriteRenderer.sortingOrder = playerTransform.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                spriteRenderer.sortingOrder = playerTransform.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
            }
        }
    }
}
