using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Minigame")]
    public class DecisionMinigame : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            MiniGameManager._miniGameManager.StartMiniGame(GameNames.OntaleScene);
            return true;
        }
    }
}