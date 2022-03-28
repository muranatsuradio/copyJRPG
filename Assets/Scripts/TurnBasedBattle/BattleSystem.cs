using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedBattle
{
    public enum BattleState
    {
        Start,
        PlayerTurn,
        EnemyTurn,
        Won,
        Lost,
    }

    public class BattleSystem : Singleton<BattleSystem>
    {
        public BattleState State;

        public GameObject PlayerPrefab;
        public GameObject EnemyPrefab;

        public Transform PlayerBattleStation;
        public Transform EnemyBattleStation;

        public Text DialogueText;

        public BattleHUD PlayerHUD;
        public BattleHUD EnemyHUD;

        private BaseUnit _playerUnit;
        private BaseUnit _enemyUnit;
    
        private void Start()
        {
            State = BattleState.Start;
            SetupBattle();
        }

        private void SetupBattle()
        {
            var playerGo = Instantiate(PlayerPrefab, PlayerBattleStation);
            _playerUnit = playerGo.GetComponent<BaseUnit>();
        
            var enemyGo = Instantiate(EnemyPrefab, EnemyBattleStation);
            _enemyUnit = enemyGo.GetComponent<BaseUnit>();

            DialogueText.text = " A wild " + _enemyUnit.UnitName + " approaches!!! ";
            
            PlayerHUD.SetHUD(_playerUnit);
            EnemyHUD.SetHUD(_enemyUnit);
        }
    }
}