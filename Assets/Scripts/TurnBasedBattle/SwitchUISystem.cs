using System;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedBattle
{
    public enum UIState
    {
        MainMenu,
        SkillMenu,
        ItemMenu,
    }

    [System.Serializable]
    public struct UIStateStruct
    {
        public UIState UIState;
        public GameObject UIObject;
    }
    
    public class SwitchUISystem : Singleton<SwitchUISystem>
    {
        [SerializeField] private List<UIStateStruct> UIStateStructs = new List<UIStateStruct>();
        
        private readonly Dictionary<UIState, GameObject> _uiStateMap = new Dictionary<UIState, GameObject>();

        private UIState _currentUIState = UIState.MainMenu;

        private void Start()
        {
            foreach (var uiState in UIStateStructs)
            {
                _uiStateMap.Add(uiState.UIState, uiState.UIObject);
            }
        }

        public void SetUiState(UIState newState)
        {
            _uiStateMap[_currentUIState].SetActive(false);
            _uiStateMap[newState].SetActive(true);
            _currentUIState = newState;
        }
    }
}
