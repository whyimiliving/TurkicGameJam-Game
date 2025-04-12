using UnityEngine;
using System.Collections.Generic;

public class LightSwitchPuzzleManager : MonoBehaviour
{
    public static LightSwitchPuzzleManager Instance;

    public List<LightTile> allLights;
   

    private List<string> pressedButtonOrder = new();
    private int currentIndex = 0;
    private bool puzzleSolved = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void RegisterButtonPress(string buttonID)
    {
        if (puzzleSolved) return;

        if (buttonID != null)
        {
            pressedButtonOrder.Add(buttonID);
            currentIndex++;

            if (AreAllLightsOn())
            {
                puzzleSolved = true;
                Debug.Log("🎉 Puzzle Solved!");
                // FSM geçişi buradan tetiklenebilir
            }
        }

    }

    private bool AreAllLightsOn()
    {
        foreach (var light in allLights)
        {
            if (!light.IsOn) return false;
        }
        return true;
    }

    public void ResetPuzzle()
    {
        Debug.Log("❌ Yanlış sıra! Puzzle resetleniyor...");

        foreach (var light in allLights)
            light.TurnOff();

        pressedButtonOrder.Clear();
        currentIndex = 0;
        puzzleSolved = false;
    }

    public bool PuzzleSolved => puzzleSolved;
}
