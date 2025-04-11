#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using FSM;

public class FSMStateBatchCreator : EditorWindow
{
    private string baseName = "State_";
    private int count = 3;
    private string savePath = "Assets/FSMObjects/States/";

    [MenuItem("FSM Tools/Create Multiple FSM States")]
    public static void ShowWindow()
    {
        GetWindow<FSMStateBatchCreator>("FSM State Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("FSM State Batch Creator", EditorStyles.boldLabel);
        baseName = EditorGUILayout.TextField("Base Name", baseName);
        count = EditorGUILayout.IntField("Count", count);
        savePath = EditorGUILayout.TextField("Save Path", savePath);

        if (GUILayout.Button("Create States"))
        {
            CreateStates();
        }
    }

    private void CreateStates()
    {
        for (int i = 0; i < count; i++)
        {
            FSMState state = ScriptableObject.CreateInstance<FSMState>();
            state.ID = baseName + i;
            AssetDatabase.CreateAsset(state, $"{savePath}{baseName}{i}.asset");
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
#endif