using System;
using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions Texts/Show Dialog")]
    public class ActionShowDialog : FSMAction
    {
        [TextArea] public string[] lines;
        
        private int index = -1;
        public static bool DialogFinished = false;


        private void OnEnable()
        {
            index = -1;
            DialogFinished = false;
        }

        public override void Act(FSMContext context)
        {
            if (DialogUI.Instance.IsTyping) return;
          
            
            if (index == -1)
            {
                index = 0;
                DialogUI.Instance.panel.SetActive(true);
                DialogFinished = false;
                DialogUI.Instance.ShowLine(lines[index]);
                index++;
                return;
            }

            if (!Input.GetKeyDown(KeyCode.Space)) return;

            if (index < lines.Length)
            {
                DialogUI.Instance.ShowLine(lines[index]);
                index++;

                if (index >= lines.Length)
                {
                    DialogFinished = true;
                }
            }
        }
    }
}