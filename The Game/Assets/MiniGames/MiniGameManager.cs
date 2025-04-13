using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

public static class GameNames
{
    public const string OntaleScene = "OntaleScene";
    public const string TcgScene = "TcgScene";
    public const string TcgScene2 = "TcgScene2";
}

[System.Serializable]
public class ItemHolderPair
{
    public string Name;
    [SerializeField] public ItemHolder[] myItems;
}

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager _miniGameManager;
    public GameObject[] onlyInMainGame;
    public GameObject backpackEvents;
    public bool isIngame; 
    [SerializeField] public ItemHolderPair[] gameCards;
    public string loadedSceneName;
    

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

    void Start()
    {
        backpackEvents.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartMiniGame(GameNames.OntaleScene);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartMiniGame(GameNames.TcgScene);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartMiniGame(GameNames.TcgScene2);
        }
    }

    public void StartMiniGame(string gameName)
    {
        isIngame = true;
        RenderGameobjects();
        loadedSceneName = gameName;
        if (gameName == GameNames.OntaleScene)
        {
            StopMainGame();
            StartOntaleGame();
        }
        else if (gameName == GameNames.TcgScene)
        {
            StopMainGame();
            StartTcgGame();
        }
        else if (gameName == GameNames.TcgScene2)
        {
            StopMainGame();
            StartTcg2Game();
        }
    }

    public void StopMainGame()
    {

    }

    public void CheckForItems(string gameName)
    {
        var existingHolder = gameCards.FirstOrDefault(c => c.Name == gameName);
        if (existingHolder != null)
        {
            InventoryManager._inventoryManager.AddCards(existingHolder.myItems);
        }
    }

    public void StartOntaleGame()
    {
        SceneManager.LoadScene(GameNames.OntaleScene, LoadSceneMode.Additive);
    }

    public void StartTcgGame()
    {
        SceneManager.LoadScene(GameNames.TcgScene, LoadSceneMode.Additive);
    }
    public void StartTcg2Game()
    {
        SceneManager.LoadScene(GameNames.TcgScene2, LoadSceneMode.Additive);
    }

    public void CloseMinigame(string gameName, bool isGood)
    {
        if (isGood)
        {
            CheckForItems(GameNames.OntaleScene);
        }
        else
        {
            StartCoroutine(RestartScene(gameName));
            return;
        }

        SceneManager.UnloadSceneAsync(gameName);
        isIngame = false;
        RenderGameobjects();
    }

    IEnumerator RestartScene(string gameName)
    {
        backpackEvents.SetActive(true);
        backpackEvents.GetComponent<BackpackEvents>().TriggerShake();
        InventoryManager._inventoryManager.RemoveLestValueable();
        yield return new WaitForSeconds(4);
        backpackEvents.SetActive(false);
        SceneManager.UnloadSceneAsync(gameName);
        SceneManager.LoadScene(gameName, LoadSceneMode.Additive);
    }

    private void RenderGameobjects()
    {
        foreach (var item in onlyInMainGame)
        {
            item.SetActive(!isIngame);
        }
    }
}
