using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public string buttonID;
    public LightTile[] controlledLights;

    public void PressButton()
    {
        foreach (var light in controlledLights)
        {
            light.Toggle();
        }

        LightSwitchPuzzleManager.Instance.RegisterButtonPress(buttonID);
    }
}