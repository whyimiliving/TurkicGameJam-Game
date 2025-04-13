using UnityEngine;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Next State")]
    public class ActionNextState : FSMAction
    {
        public string sceneName;

        public override void Act(FSMContext context)
        {
            Debug.Log("🔥 ActionNextState çağrıldı, sahne adı: " + sceneName);

            if (SceneLoaderManager.Instance != null)
            {
                SceneLoaderManager.Instance.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("⚠️ SceneLoaderManager bulunamadı!");
            }
        }
    }
}