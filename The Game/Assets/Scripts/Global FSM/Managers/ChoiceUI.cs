using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using FSM.Actions;

public class ChoiceUI : MonoBehaviour
{
    public static ChoiceUI Instance;

    public GameObject choicePanel;
    public Button[] choiceButtons;
    public TextMeshProUGUI[] choiceTexts;

    public string LastSelectedID { get; private set; } = "";

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int index = i;
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
        }
    }

    private ChoiceOption[] currentOptions;

    public void DisplayBlock(ChoiceBlock block)
    {
        LastSelectedID = "";
        currentOptions = block.choices;
        choicePanel.SetActive(true);

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < block.choices.Length)
            {
                choiceTexts[i].text = block.choices[i].displayText;
                choiceButtons[i].gameObject.SetActive(true);
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnChoiceSelected(int index)
    {
        if (currentOptions == null || index >= currentOptions.Length) return;
        LastSelectedID = currentOptions[index].choiceID;
        Debug.Log("Seçilen ID: " + LastSelectedID);
        choicePanel.SetActive(false);
    }
}
