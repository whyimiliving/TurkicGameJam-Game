using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Enable Puzzle")]
    public class ActionEnablePuzzle : FSMAction
    {
        public string puzzleName;

        public override void Act(FSMContext context)
        {
            PuzzleManager.Instance.EnablePuzzle(puzzleName);
        }
    }
}