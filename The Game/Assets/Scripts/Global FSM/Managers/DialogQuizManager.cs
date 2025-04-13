using UnityEngine;
using System.Collections.Generic;

public class DialogQuizManager : MonoBehaviour
{
    public static DialogQuizManager Instance;

    [SerializeField] private List<QuestionData> questionPool = new();
    private List<QuestionData> currentQuiz = new();
    private int currentIndex = 0;
    public int correctCount = 0;
    public int incorrectCount = 0;
    private bool active = false;

    public int maxQuestions = 5;
    public int maxWrongAnswers = 2;

    public bool QuizPassed => correctCount == 5;
    public bool QuizFailed => incorrectCount == maxWrongAnswers;
    public bool QuizInProgress => active;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void StartQuiz()
    {
        PlayerMovement.Instance.canMove = false;
        DialogQuizUI.Instance.panel.SetActive(true);
        currentQuiz.Clear();
        currentIndex = 0;
        correctCount = 0;
        incorrectCount = 0;
        active = true;

        List<QuestionData> temp = new(questionPool);
        for (int i = 0; i < maxQuestions; i++)
        {
            int rand = Random.Range(0, temp.Count);
            currentQuiz.Add(temp[rand]);
            temp.RemoveAt(rand);
        }

        ShowCurrentQuestion();
    }

    public void ShowCurrentQuestion()
    {
        if (currentIndex >= currentQuiz.Count) return;

        QuestionData q = currentQuiz[currentIndex];
        DialogQuizUI.Instance.ShowQuestion(q, OnAnswerSelected);
    }

    private void OnAnswerSelected(int selectedIndex)
    {
        if (!active) return;

        QuestionData q = currentQuiz[currentIndex];

        if (selectedIndex == q.correctAnswerIndex)
            correctCount++;
        else
            incorrectCount++;

        currentIndex++;

        if (QuizPassed || QuizFailed)
        {
            PlayerMovement.Instance.canMove = true;
            PlayerMovement.Instance.moveSpeed = 3;
            active = true;
        }
        else
        {
            ShowCurrentQuestion();
        }
    }

    public void ResetQuiz()
    {
        active = false;
        correctCount = 0;
        incorrectCount = 0;
        currentIndex = 0;
    }
}
