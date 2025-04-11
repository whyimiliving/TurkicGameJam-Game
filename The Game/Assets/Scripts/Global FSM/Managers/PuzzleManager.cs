using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    private HashSet<string> solvedPuzzles = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void EnablePuzzle(string puzzleName)
    {
        Debug.Log($"Puzzle activated: {puzzleName}");
        Invoke(nameof(FinishPuzzle), 3f);
    }

    private void FinishPuzzle()
    {
        Debug.Log("Puzzle simulation complete");
    }

    public void SolvePuzzle(string puzzleName)
    {
        Debug.Log($"Puzzle solved: {puzzleName}");
        solvedPuzzles.Add(puzzleName);
    }

    public bool IsPuzzleSolved(string puzzleName)
    {
        return solvedPuzzles.Contains(puzzleName);
    }
}