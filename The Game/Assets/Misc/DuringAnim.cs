using UnityEngine;

public class DuringAnim : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<IAnimStarter>().ChangeConditionMet();
    }
}
