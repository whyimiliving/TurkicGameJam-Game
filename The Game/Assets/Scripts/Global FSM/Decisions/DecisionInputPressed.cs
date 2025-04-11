using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Input Pressed")]
    public class DecisionInputPressed : FSMDecision
    {
        public string inputName = "Submit";

        public override bool Decide(FSMContext context)
        {
            return Input.GetButtonDown(inputName);
        }
    }
}