using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class DialogUI_Dual : MonoBehaviour
{
    public static DialogUI_Dual Instance;

    public GameObject panel;
    public TextMeshProUGUI speakerAText;
    public TextMeshProUGUI speakerBText;

    public float letterPause = 0.03f;
    public bool IsTyping { get; private set; }

    private int currentLineIndex = 0;
    private string[] currentLines;

    private void Awake()
    {
        if (Instance == null) Instance = this;
       
    }


    private void OnEnable()
    {
        currentLineIndex = 0;
        currentLines = null;
    }

    public void StartDialog(string[] lines)
    {
        currentLines = lines;
        currentLineIndex = 0;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLines == null || currentLineIndex >= currentLines.Length) return;

        string line = currentLines[currentLineIndex];
        bool isA = currentLineIndex % 2 == 0;

        if (isA)
        {
            StartCoroutine(TypeLine(speakerAText, line.Trim(), speakerBText));
        }
        else
        {
            StartCoroutine(TypeLine(speakerBText, line.Trim(), speakerAText));
        }

        currentLineIndex++;
    }

    private IEnumerator TypeLine(TextMeshProUGUI activeField, string text, TextMeshProUGUI otherField)
    {
        panel.SetActive(true);
        activeField.text = "";
        otherField.text = "";
        IsTyping = true;

        foreach (char letter in text)
        {
            activeField.text += letter;
            yield return new WaitForSeconds(letterPause);
        }

        IsTyping = false;
    }

    public void Hide()
    {
        speakerAText.text = "";
        speakerBText.text = "";
        panel.SetActive(false);
        IsTyping = false;
        currentLineIndex = 0;
        currentLines = null;
    }

    public bool IsFinished()
    {
        return currentLines == null || currentLineIndex >= currentLines.Length;
    }
}