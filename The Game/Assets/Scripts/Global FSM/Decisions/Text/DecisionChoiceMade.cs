using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions Text/Choice Made")]
    public class DecisionChoiceMade : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            return !string.IsNullOrEmpty(ChoiceUI.Instance.LastSelectedID);
        }
    }
}