using UnityEngine;

public class DuringAnim : StateMachineBehaviour
{
    public bool isDance;
    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isDance)
        {
            animator.SetBool("AttackDance", true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isDance)
        {
            animator.SetBool("AttackDance", false);
        }
        animator.gameObject.GetComponent<IAnimStarter>().ChangeConditionMet();
    }
}
