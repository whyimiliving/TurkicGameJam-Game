using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public static class GameNames
{
    public const string OntaleScene = "OntaleScene";
}

public class MiniGameManager : MonoBehaviour
{

    void Start()
    {

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

    public void StartOntaleGame()
    {
        SceneManager.LoadScene(GameNames.OntaleScene, LoadSceneMode.Additive);
    }
}
