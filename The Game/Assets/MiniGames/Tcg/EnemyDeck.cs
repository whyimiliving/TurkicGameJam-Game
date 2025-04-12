using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    public List<CardItem> deckCards;
    public GameObject EnemyMonster;
    public Transform EnemyMonsterParent;

    void Start()
    {
        StartCoroutine(StartFight());
    }

    IEnumerator StartFight()
    {
        Debug.Log("Bişiler Söyle");
        yield return new WaitForSeconds(3);
        //yield return new WaitUntil(() => conditionMet);
        Debug.Log("start");
        Summon();
    }

    public void NextEnemyCard()
    {
        Hand._hand.ClearHand();
        StartCoroutine(SayRandom());
    }

    IEnumerator SayRandom()
    {
        if (deckCards.Count <= 0)
        {
            Debug.Log("kaybettim gg");
            yield return new WaitForSeconds(5);
            MiniGameManager._miniGameManager.CloseMinigame(GameNames.TcgScene, true);
        }
        else
        {
            Debug.Log("Başka Bişiler Söyle");
            yield return new WaitForSeconds(5);
            Summon();
        }
    }

    public void Summon()
    {
        var monster = Instantiate(EnemyMonster, EnemyMonsterParent);
        monster.GetComponent<EnemyMonster>().SetMe(deckCards[0], this);
        deckCards.RemoveAt(0);
    }

    public void RemoveFromDeck(int index)
    {
        deckCards.RemoveAt(index);
    }
}
