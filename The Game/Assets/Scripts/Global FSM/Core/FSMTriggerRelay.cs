using FSM.Decisions;
using UnityEngine;

public class FSMTriggerRelay : MonoBehaviour
{
    public DecisionTriggerEntered decision;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (decision != null)
        {
            decision.TriggerHit(other);
        }
    }
}