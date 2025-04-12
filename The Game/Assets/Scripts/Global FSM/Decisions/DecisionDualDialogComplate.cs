using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Dual Dialog Complete")]
    public class DecisionDualDialogComplete : FSMDecision
    {
        private float delayTimer = 0f;
        private bool countdownStarted = false;
        [SerializeField] private float delayAfterFinish = 1.5f;

        public override bool Decide(FSMContext context)
        {
            if (DialogUI_Dual.Instance == null) return false;

            if (DialogUI_Dual.Instance.IsTyping)
            {
                delayTimer = 0f;
                countdownStarted = false;
                return false;
            }

            if (DialogUI_Dual.Instance.IsFinished())
            {
                if (!countdownStarted)
                {
                    delayTimer = 0f;
                    countdownStarted = true;
                }

                delayTimer += Time.deltaTime;

                if (delayTimer >= delayAfterFinish)
                {
                    DialogUI_Dual.Instance.Hide();
                    countdownStarted = false;
                    return true;
                }
            }
            else
            {
                delayTimer = 0f;
                countdownStarted = false;
            }

            return false;
        }
    }
}