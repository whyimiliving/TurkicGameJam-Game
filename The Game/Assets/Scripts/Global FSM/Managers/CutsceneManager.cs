using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;

    private bool cutscenePlaying = false;
    private string currentCutsceneName = "";

    public bool IsCutsceneFinished => !cutscenePlaying;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayCutscene(string cutsceneName)
    {
        if (cutscenePlaying) return;
        cutscenePlaying = true;
        currentCutsceneName = cutsceneName;
        Debug.Log($"Playing cutscene: {cutsceneName}");
        Invoke(nameof(EndCutscene), 3f);
    }

    private void EndCutscene()
    {
        Debug.Log($"Cutscene finished: {currentCutsceneName}");
        cutscenePlaying = false;
        currentCutsceneName = "";
    }
}