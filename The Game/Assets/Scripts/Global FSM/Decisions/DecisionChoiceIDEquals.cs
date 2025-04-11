using UnityEngine;

namespace FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decisions/Choice ID Equals")]
    public class DecisionChoiceIDEquals : FSMDecision
    {
        public string[] matchIDs;

        public override bool Decide(FSMContext context)
        {
            string selectedID = ChoiceUI.Instance.LastSelectedID;
            Debug.Log($"[DEBUG] FSMDecision_ChoiceIDEquals çalıştı: selectedID = {selectedID}");

            if (string.IsNullOrEmpty(selectedID)) return false;

            foreach (var id in matchIDs)
            {
                Debug.Log($"[DEBUG] Karşılaştırma: selectedID = {selectedID}, match = {id}");
                if (selectedID == id)
                {
                    Debug.Log($"✅ ID eşleşti: {selectedID}");
                    return true;
                }
            }

            return false;
        }

    }
}
