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
        public void TriggerHit(Collider2D other, GameObject triggerObject)
        {
            if (other.CompareTag(triggerTag))
            {
                triggered = true;
                PlayerMovement.Instance.canMove = false;
                PlayerMovement.Instance.movement = Vector3.zero;
                Debug.Log("✅ Trigger tetiklendi!");

                Destroy(triggerObject); 
            }
        }

        public override bool Decide(FSMContext context)
        {
           if(triggered)
           {
               return true;
           }
           return false;
        }

        public override void ResetDecision()
        {
            triggered = false;
            Debug.Log("🔁 DecisionTriggerEntered resetlendi.");
        }
    }
}