using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions Legacy/Minigame")]
    public class DecisionMinigame : FSMDecision
    {
        public string gameNamee;
        
        public override bool Decide(FSMContext context)
        {
            
            
            MiniGameManager._miniGameManager.StartMiniGame(gameNamee);
            return true;
        }
    }
}