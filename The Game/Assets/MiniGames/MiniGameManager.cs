using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public static class GameNames
{
    public const string OntaleScene = "OntaleScene";
    public const string TcgScene = "TcgScene";
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
    public bool isIngame; 
    [SerializeField] public ItemHolderPair[] gameCards;
    

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
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartMiniGame(GameNames.TcgScene);
        }
    }

    public void StartMiniGame(string gameName)
    {
        isIngame = true;
        RenderGameobjects();
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

    public void CloseMinigame(string gameName, bool isGood)
    {
        SceneManager.UnloadSceneAsync(gameName);
        if (isGood)
        {
            CheckForItems(GameNames.OntaleScene);
        }
        else
        {
            InventoryManager._inventoryManager.RemoveLestValueable();
        }

        isIngame = false;
        RenderGameobjects();
    }

    private void RenderGameobjects()
    {
        foreach (var item in onlyInMainGame)
        {
            item.SetActive(!isIngame);
        }
    }
}
