using UnityEngine;

namespace FSM
{
    public abstract class FSMAction : ScriptableObject
    {
        public abstract void Act(FSMContext context);
        public virtual void OnExit(FSMContext context) { }
    }
}