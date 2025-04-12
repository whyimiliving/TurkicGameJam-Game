using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Restore Main Music")]
    public class ActionRestoreMainMusic : FSMAction
    {
        public float fadeTime = 0.5f;

        public override void Act(FSMContext context)
        {
            SoundManager.Instance.RestoreMainMusic(fadeTime);
        }
    }
}