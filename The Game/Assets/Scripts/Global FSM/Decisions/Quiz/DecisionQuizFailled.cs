using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Quiz Failed")]
    public class DecisionQuizFailed : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
         //   Debug.Log("Yanlıs:"+ DialogQuizManager.Instance.incorrectCount);
            return DialogQuizManager.Instance.QuizInProgress &&
                   DialogQuizManager.Instance.QuizFailed;
        }
    }
}