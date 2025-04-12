using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions Quiz/Quiz Passed")]
    public class DecisionQuizPassed : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
           // Debug.Log($"[FSM] QuizPassed: {DialogQuizManager.Instance.QuizPassed}, InProgress: {DialogQuizManager.Instance.QuizInProgress}");
          //  Debug.Log("Dogru" + DialogQuizManager.Instance.correctCount);
            return DialogQuizManager.Instance.QuizInProgress &&
                   DialogQuizManager.Instance.QuizPassed;
        }
    }
}