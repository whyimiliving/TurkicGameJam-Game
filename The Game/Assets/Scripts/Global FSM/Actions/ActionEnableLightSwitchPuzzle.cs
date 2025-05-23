﻿using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/Enable Light Switch Puzzle")]
    public class ActionEnableLightSwitchPuzzle : FSMAction
    {
        private bool started = false;

        private void OnEnable()
        {
            started = false;
        }

        public override void Act(FSMContext context)
        {
            if (started) return;

            if (LightSwitchPuzzleManager.Instance != null)
            {
                LightSwitchPuzzleManager.Instance.ResetPuzzle();
                Debug.Log("🔄 Light Puzzle başlatıldı.");
                started = true;
            }
        }

        public override void OnExit(FSMContext context)
        {
            started = false; // state değişince sıfırla
        }
    }
}