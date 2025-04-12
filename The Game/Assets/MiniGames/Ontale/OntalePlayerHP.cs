using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class OntalePlayerHP : MonoBehaviour
{
    public float currentHp;
    public float maxHp;
    public TextMeshProUGUI hpText;

    private void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            TakeDmg(1);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDmg(float dmg)
    {
        currentHp -= dmg;
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        hpText.text = currentHp.ToString();
    }
}
