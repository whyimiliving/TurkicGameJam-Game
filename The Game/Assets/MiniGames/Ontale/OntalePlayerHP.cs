using UnityEngine;
using TMPro;
using UnityEditor.UI;
using UnityEngine.UI;

public class OntalePlayerHP : MonoBehaviour
{
    public float currentHp;
    public float maxHp;
    public TextMeshProUGUI hpText;
    public RawImage hpImg;

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
        Vector3 currentScale = hpImg.rectTransform.localScale;
        currentScale.x = (currentHp/maxHp);
        hpImg.rectTransform.localScale = currentScale;
    }
}
