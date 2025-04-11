using UnityEngine;

namespace FSM
{
    public class FSMBrain : MonoBehaviour
    {
        public FSMState[] states;
        public string initialStateID;

        private FSMState currentState;
        private FSMContext context;

        private void Start()
        {
            context = new FSMContext(gameObject);
            ChangeState(initialStateID);
        }

        private void Update()
        {
            // Debug.Log("Current State: " + currentState?.ID);
            currentState?.UpdateState(context, this);
        }

        public void ChangeState(string stateID)
        {
            
            Debug.Log($"FSM ChangeState called → {stateID}");
            var newState = GetStateByID(stateID);
            if (newState == null || newState == currentState) return;

            currentState?.OnExit(context);
            currentState = newState;
            currentState?.OnEnter(context);
        }

        private FSMState GetStateByID(string id)
        {
            foreach (var state in states)
            {
                if (state.ID == id) return state;
            }
            return null;
        }
    }
}