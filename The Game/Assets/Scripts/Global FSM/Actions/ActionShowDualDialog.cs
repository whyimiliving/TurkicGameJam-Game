using System;
using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions Texts/Show Dual Dialog Timed")]
    public class ActionShowDualDialog : FSMAction
    {
        [TextArea] public string[] lines;
        public static bool DialogFinished = false;

        private bool started = false;
        private float delayTimer = 0f;
        private float delayAfterLine = 3f;
        private bool waitingForNextLine = false;
        private bool waitingToFinish = false;

        private void OnEnable()
        {
            DialogFinished = false;
            started = false;
            delayTimer = 0f;
            waitingForNextLine = false;
            waitingToFinish = false;
        }

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

            if (DialogUI_Dual.Instance.IsFinished())
            {
                // son satır gösterildi ama hemen geçmesin
                if (!waitingToFinish)
                {
                    waitingToFinish = true;
                    delayTimer = 0f;
                }

                delayTimer += Time.deltaTime;

                if (delayTimer >= delayAfterLine)
                {
                    DialogFinished = true;
                }

                return;
            }

            if (!waitingForNextLine)
            {
                waitingForNextLine = true;
                delayTimer = 0f;
            }

            delayTimer += Time.deltaTime;

            if (delayTimer >= delayAfterLine)
            {
                DialogUI_Dual.Instance.ShowNextLine();
                waitingForNextLine = false;
                delayTimer = 0f;
            }
        }
    }
}