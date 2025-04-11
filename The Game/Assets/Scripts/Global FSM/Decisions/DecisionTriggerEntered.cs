using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Trigger Entered")]
    public class DecisionTriggerEntered : FSMDecision
    {
        public string triggerTag = "Player";
        private bool triggered = false;
        private void OnEnable()
        {
            triggered = false;
        }
        public void TriggerHit(Collider2D other)
        {
            if (other.CompareTag(triggerTag))
            {
                triggered = true;
                Debug.Log("✅ Trigger tetiklendi!");
            }
        }

        public override bool Decide(FSMContext context)
        {
            return triggered;
        }

        public override void ResetDecision()
        {
            triggered = false;
            Debug.Log("🔁 DecisionTriggerEntered resetlendi.");
        }
    }
}