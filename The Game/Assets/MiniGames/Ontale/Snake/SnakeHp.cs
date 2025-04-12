using TMPro;
using UnityEngine;

public class SnakeHp : MonoBehaviour
{
    public float currentHp;
    public float maxHp;
    public TextMeshProUGUI hpText;

    private void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
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
