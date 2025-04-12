using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions Legacy/Play Cutscene")]
    public class ActionPlayCutscene : FSMAction
    {
        public string cutsceneName;

        public override void Act(FSMContext context)
        {
            CutsceneManager.Instance.PlayCutscene(cutsceneName);
        }
    }
}