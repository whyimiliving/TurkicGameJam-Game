using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Wait Till Time (No Coroutine)")]
    public class DecisionWaitTill : FSMDecision
    {
        [SerializeField] private float waitTime = 4f;

        private float startTime;
        private bool initialized = false;

        public override bool Decide(FSMContext context)
        {
            // İlk kez çalıştırılıyorsa zamanı al
            if (!initialized)
            {
                startTime = Time.time;
                initialized = true;
            }

            // Bekleme süresi geçtiyse true döner
            return Time.time - startTime >= waitTime;
        }
    }
}