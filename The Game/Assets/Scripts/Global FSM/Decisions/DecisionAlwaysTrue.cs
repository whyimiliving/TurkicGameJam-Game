using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Always True")]
    public class DecisionAlwaysTrue : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            return true;
        }
    }

}
