using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Start Dialog Quiz")]
    public class ActionStartQuiz : FSMAction
    {
        public override void Act(FSMContext context)
        {
            if (!DialogQuizManager.Instance.QuizInProgress)
            {
                DialogQuizManager.Instance.StartQuiz();
            }
        }
    }
}