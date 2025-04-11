using System;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class FSMState : ScriptableObject
    {
        public string ID;
        public FSMAction[] actions;
        public FSMTransition[] transitions;

        public virtual void OnEnter(FSMContext context) {}
        public virtual void OnExit(FSMContext context) {}

        public void UpdateState(FSMContext context, FSMBrain brain)
        {
            foreach (var action in actions)
                action?.Act(context);

            foreach (var transition in transitions)
            {
                if (transition.decision.Decide(context) == transition.requiredResult)
                {
                    brain.ChangeState(transition.targetState);
                    return;
                }
            }
        }
    }
}