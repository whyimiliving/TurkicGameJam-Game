using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Dialog Complete")]
    public class DecisionDialogComplete : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            return DialogUI.Instance.IsFinished;
        }
    }
}