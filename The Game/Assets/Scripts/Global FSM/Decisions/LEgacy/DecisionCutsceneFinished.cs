using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions Legacy/Cutscene Finished")]
    public class DecisionCutsceneFinished : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            return CutsceneManager.Instance.IsCutsceneFinished;
        }
    }
}