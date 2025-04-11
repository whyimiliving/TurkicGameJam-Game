using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Choice Made")]
    public class DecisionChoiceMade : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            return !string.IsNullOrEmpty(ChoiceUI.Instance.LastSelectedID);
        }
    }
}