using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions Text/Dialog Fully Complete")]
    public class DecisionDialogFullyComplete : FSMDecision
    {
        public override bool Decide(FSMContext context)
        {
            if (FSM.Actions.ActionShowDialog.DialogFinished && 
                !DialogUI.Instance.IsTyping && 
                Input.GetKeyDown(KeyCode.Space))
            {
                DialogUI.Instance.Hide();
                return true;
              
            }

            return false;
        }
    }

}