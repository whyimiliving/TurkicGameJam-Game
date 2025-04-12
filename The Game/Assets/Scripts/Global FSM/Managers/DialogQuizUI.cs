using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogQuizUI : MonoBehaviour
{
    public static DialogQuizUI Instance;

    public GameObject panel;
    public TextMeshProUGUI questionText;
    public Button[] choiceButtons;
    public TextMeshProUGUI[] choiceTexts;

    private System.Action<int> onChoiceSelected;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int index = i;
            choiceButtons[i].onClick.AddListener(() => {
                panel.SetActive(false);
                onChoiceSelected?.Invoke(index);
            });
        }
    }

    public void ShowQuestion(QuestionData question, System.Action<int> callback)
    {
        panel.SetActive(true);
        onChoiceSelected = callback;

        questionText.text = question.question;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < question.choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceTexts[i].text = question.choices[i];
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }
}