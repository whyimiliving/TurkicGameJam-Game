using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Show Dual Dialog")]
    public class FSMAction_ShowDualDialog : FSMAction
    {
        [TextArea] public string[] lines;
        public static bool DialogFinished = false;

        private bool started = false;

        public override void Act(FSMContext context)
        {
            if (!started)
            {
                DialogUI_Dual.Instance.StartDialog(lines);
                started = true;
                DialogFinished = false;
                return;
            }

            if (DialogUI_Dual.Instance.IsTyping) return;
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            DialogUI_Dual.Instance.ShowNextLine();

            if (!DialogUI_Dual.Instance.IsTyping && DialogUI_Dual.Instance.IsFinished())
            {
                DialogFinished = true;
            }
        }
    }
}