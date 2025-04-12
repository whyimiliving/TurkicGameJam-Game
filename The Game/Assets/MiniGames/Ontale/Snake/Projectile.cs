using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dmg;
    public float speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
