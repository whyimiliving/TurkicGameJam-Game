using System;
using UnityEngine;

namespace FSM
{
    [Serializable]
    public class FSMTransition
    {
        public FSMDecision decision;
        public string targetState;
        public bool requiredResult;
    }
}