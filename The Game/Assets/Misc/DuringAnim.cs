using UnityEngine;

public class DuringAnim : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Saldırı animasyonuna girildi");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Saldırı animasyonundan çıkıldı");
    }
}
