using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Puzzle Solved")]
    public class DecisionPuzzleSolved : FSMDecision
    {
        public string puzzleName;

        public override bool Decide(FSMContext context)
        {
            return PuzzleManager.Instance.IsPuzzleSolved(puzzleName);
        }
    }
}