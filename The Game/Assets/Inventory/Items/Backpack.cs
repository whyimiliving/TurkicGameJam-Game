using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public GameObject myBackpack;

    private void Start()
    {
        myBackpack.SetActive(false);
    }

    public void ShowBackpack()
    {
        myBackpack.SetActive(!(myBackpack.activeSelf));
    }
}
