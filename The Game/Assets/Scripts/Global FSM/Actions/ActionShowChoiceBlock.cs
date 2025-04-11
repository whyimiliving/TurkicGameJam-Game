using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Show Choice Block")]
    public class FSMAction_ShowChoiceBlock : FSMAction
    {
        public ChoiceBlock block;

        public override void Act(FSMContext context)
        {
            ChoiceUI.Instance.DisplayBlock(block);
        }
    }
}