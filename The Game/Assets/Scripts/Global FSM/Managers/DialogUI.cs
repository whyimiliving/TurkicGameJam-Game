using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogUI : MonoBehaviour
{
    public static DialogUI Instance;

    public GameObject panel;
    public TextMeshProUGUI dialogText;

    public float letterPause = 0.05f;

    public bool IsTyping { get; private set; }
    public bool IsFinished { get; private set; }

    private Coroutine typeCoroutine;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowLine(string line)
    {
        if (typeCoroutine != null)
            StopCoroutine(typeCoroutine);
        typeCoroutine = StartCoroutine(TypeLine(line));
    }

    private IEnumerator TypeLine(string line)
    {
        panel.SetActive(true);
        dialogText.text = "";
        IsTyping = true;
        IsFinished = false;
        foreach (char letter in line)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(letterPause);
        }
        IsTyping = false;
        IsFinished = true;
    }

    public void Hide()
    {
        panel.SetActive(false);
        dialogText.text = "";
        IsTyping = false;
        IsFinished = false;
    }
    
    public void Show()
    {
        panel.SetActive(true);
 
    }
}
