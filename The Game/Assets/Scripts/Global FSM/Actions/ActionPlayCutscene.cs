using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Play Cutscene")]
    public class ActionPlayCutscene : FSMAction
    {
        public string cutsceneName;

        public override void Act(FSMContext context)
        {
            CutsceneManager.Instance.PlayCutscene(cutsceneName);
        }
    }
}