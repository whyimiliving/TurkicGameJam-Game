using UnityEngine;

[CreateAssetMenu(menuName = "Quiz/Question")]
public class QuestionData : ScriptableObject
{
    [TextArea] public string question;
    public string[] choices;
    public int correctAnswerIndex;
}