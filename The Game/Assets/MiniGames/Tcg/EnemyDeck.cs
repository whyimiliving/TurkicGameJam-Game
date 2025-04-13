using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    public List<CardItem> deckCards;
    public GameObject EnemyMonster;
    public Transform EnemyMonsterParent;
    public TextMeshProUGUI cardLeft;

    void Start()
    {
        UpdateGui();
        StartCoroutine(StartFight());
    }
    void UpdateGui()
    {
        cardLeft.text = deckCards.Count.ToString();
    }

    IEnumerator StartFight()
    {
        Debug.Log("Bişiler Söyle");
        yield return new WaitForSeconds(3);
        //yield return new WaitUntil(() => conditionMet);
        Debug.Log("start");
        Summon();
        UpdateGui();
    }

    public void NextEnemyCard()
    {
        Hand._hand.ClearHand();
        StartCoroutine(SayRandom());
    }

    IEnumerator SayRandom()
    {
        StartCoroutine(ShowTextOneByOne(strings[Random.Range(0, strings.Length)]));
        if (deckCards.Count <= 0)
        {
            yield return new WaitForSeconds(5);
            MiniGameManager._miniGameManager.CloseMinigame(GameNames.TcgScene, true);
        }
        else
        {
            yield return new WaitForSeconds(5);
            Summon();
        }
    }

    public void Summon()
    {
        var monster = Instantiate(EnemyMonster, EnemyMonsterParent);
        monster.GetComponent<EnemyMonster>().SetMe(deckCards[0], this);
        deckCards.RemoveAt(0);
        UpdateGui();
    }

    public void RemoveFromDeck(int index)
    {
        deckCards.RemoveAt(index);
    }

#region Chat
    public TextMeshProUGUI chatTmp;
    public float typingSpeed = 0.15f;
    public string[] strings;

    IEnumerator ShowTextOneByOne(string fullText)
    {
        chatTmp.text = "";
        foreach (char c in fullText)
        {
            chatTmp.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
#endregion
}
