using UnityEngine;

public class HitDuringAnim : StateMachineBehaviour
{
    public GameObject sfx;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(sfx);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<IAnimStarter>().ChangeConditionMet();
    }
}
