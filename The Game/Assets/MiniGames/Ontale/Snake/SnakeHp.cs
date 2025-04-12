using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnakeHp : MonoBehaviour
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

    public void TakeDmg(float dmg)
    {
        currentHp -= dmg;
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        hpText.text = currentHp.ToString();
        Vector3 currentScale = hpImg.rectTransform.localScale;
        currentScale.x = (currentHp / maxHp);
        hpImg.rectTransform.localScale = currentScale;
    }
}
