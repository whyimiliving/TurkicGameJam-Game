using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Light Switch Puzzle Solved")]
    public class DecisionPuzzleSolved : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            return LightSwitchPuzzleManager.Instance != null &&
                   LightSwitchPuzzleManager.Instance.PuzzleSolved;
        }
    }
}