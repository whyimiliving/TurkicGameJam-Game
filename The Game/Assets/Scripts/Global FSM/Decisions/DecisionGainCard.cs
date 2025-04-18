using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/ Card Gain")]
    public class DecisionGainCard : FSMDecision
    {
        public string gameNamee;
        
        public override bool Decide(FSMContext context)
        {
            MiniGameManager._miniGameManager.CheckForItems(gameNamee);
            return true;
        }
    }
}