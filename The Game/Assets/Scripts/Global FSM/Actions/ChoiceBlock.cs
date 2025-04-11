using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Choice Block")]
    public class ChoiceBlock : ScriptableObject
    {
        public ChoiceOption[] choices;
    }

}