using UnityEngine;

public class DuringAnim : StateMachineBehaviour
{
    public bool isDance;
    public GameObject Sfx1;

    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isDance)
        {
            animator.SetBool("AttackDance", true);
        }
        if (Sfx1)
        {
            Instantiate(Sfx1);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isDance)
        {
            animator.SetBool("AttackDance", false);
        }
        if (Sfx1)
        {
            Destroy(Sfx1);
        }
        animator.gameObject.GetComponent<IAnimStarter>().ChangeConditionMet();
    }
}
