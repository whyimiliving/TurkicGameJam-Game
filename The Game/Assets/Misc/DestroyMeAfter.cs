using UnityEngine;

public class DestroyMeAfter : MonoBehaviour
{
    public float lifeTime;
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
