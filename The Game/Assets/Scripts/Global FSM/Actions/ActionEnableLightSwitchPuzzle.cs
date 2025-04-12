using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Enable Light Switch Puzzle")]
    public class FSMAction_EnableLightSwitchPuzzle : FSMAction
    {
        private bool started = false;

        public override void Act(FSMContext context)
        {
            if (started) return;

            if (LightSwitchPuzzleManager.Instance != null)
            {
                LightSwitchPuzzleManager.Instance.ResetPuzzle();
                Debug.Log("🔄 Light Puzzle başlatıldı.");
                started = true;
            }
        }

        public override void OnExit(FSMContext context)
        {
            started = false; // state değişince sıfırla
        }
    }
}