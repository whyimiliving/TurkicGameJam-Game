using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public static class GameNames
{
    public const string OntaleScene = "OntaleScene";
}

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager _miniGameManager;

    void Awake()
    {
        if (_miniGameManager == null)
        {
            _miniGameManager = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartMiniGame(GameNames.OntaleScene);
        }
    }

    public void StartMiniGame(string gameName)
    {
        if (gameName == GameNames.OntaleScene)
        {
            StopMainGame();
            StartOntaleGame();
        }
    }

    public void StopMainGame()
    {

    }

    public void CheckForItems(string gameName)
    {
        if (gameName == GameNames.OntaleScene)
        {
            // TODO: itemlerı koy
        }
    }

    public void StartOntaleGame()
    {
        SceneManager.LoadScene(GameNames.OntaleScene, LoadSceneMode.Additive);
    }

    public void CloseMinigame(string gameName)
    {
        SceneManager.UnloadSceneAsync(gameName);
        CheckForItems(GameNames.OntaleScene);
    }
}
