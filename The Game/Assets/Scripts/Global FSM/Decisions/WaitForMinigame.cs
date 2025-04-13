using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions Legacy/Minigame Wait")]
    public class WaitForMinigame : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            if (!MiniGameManager._miniGameManager.isIngame)
            {
                return true;
            }
            
            return false;
        }
    }
}