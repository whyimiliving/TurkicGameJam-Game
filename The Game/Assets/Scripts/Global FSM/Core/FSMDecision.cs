using UnityEngine;

namespace FSM
{
    public abstract class FSMDecision : ScriptableObject
    {
        public abstract bool Decide(FSMContext context);
        
        public virtual void ResetDecision()
        {
            // override edilebilir
        }

    }
}