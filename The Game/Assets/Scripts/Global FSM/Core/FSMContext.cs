using UnityEngine;

namespace FSM
{
    public class FSMContext
    {
        public GameObject Owner;
        public Transform Transform;
        public MonoBehaviour Mono;

        public FSMContext(GameObject owner)
        {
            Owner = owner;
            Transform = owner.transform;
            Mono = owner.GetComponent<MonoBehaviour>();
        }
    }
}