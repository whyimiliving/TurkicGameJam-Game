using System.Collections;
using System.Threading;
using UnityEngine;

public class SnakeMain : MonoBehaviour
{
    public Animator animator;

    private bool conditionMet = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator StartFight()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Bişiler Söyle");
        yield return new WaitUntil(() => conditionMet);
        Debug.Log("");

    }


    IEnumerator Attack()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("");
        yield return new WaitUntil(() => conditionMet);
        Debug.Log("");

    }
}

public class SnakeAttack
{
    public Transform[] startTransforms;
    public GameObject projectile;
}