using UnityEngine;

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
