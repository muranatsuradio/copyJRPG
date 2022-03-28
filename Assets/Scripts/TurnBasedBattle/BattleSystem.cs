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
            StartCoroutine(SetupBattle());
        }

        private IEnumerator SetupBattle()
        {
            var playerGo = Instantiate(PlayerPrefab, PlayerBattleStation);
            _playerUnit = playerGo.GetComponent<BaseUnit>();

            var enemyGo = Instantiate(EnemyPrefab, EnemyBattleStation);
            _enemyUnit = enemyGo.GetComponent<BaseUnit>();

            DialogueText.text = " A wild " + _enemyUnit.UnitName + " approaches!!! ";

            PlayerHUD.SetHUD(_playerUnit);
            EnemyHUD.SetHUD(_enemyUnit);

            yield return new WaitForSeconds(2f);

            State = BattleState.PlayerTurn;
            PlayerTurn();
        }

        #region PlayerTurn
        
        private void PlayerTurn()
        {
            DialogueText.text = "CHOOSE AN ACTION: ";
        }

        private IEnumerator PlayerAttack()
        {
            var isDead = _enemyUnit.TakeDamage(_playerUnit.Damage);
            
            EnemyHUD.SetHp((float)_enemyUnit.CurrentHp/(float)_enemyUnit.MaxHp);
            DialogueText.text = "THE ATTACK IS SUCCESSFUL!!";
            
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                State = BattleState.Won;
                EndBattle();
            }
            else
            {
                State = BattleState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
        }

        
        
        public void OnAttackButton()
        {
            if (State != BattleState.PlayerTurn) return;

            StartCoroutine(PlayerAttack());
        }
        #endregion

        #region EnemyTurn

        private IEnumerator EnemyTurn()
        {
            DialogueText.text = _enemyUnit.UnitName + " ATTACKS!";

            yield return new WaitForSeconds(1f);

            var isDead = _playerUnit.TakeDamage(_enemyUnit.Damage);
            
            PlayerHUD.SetHp((float)_playerUnit.CurrentHp/(float)_playerUnit.MaxHp);

            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                State = BattleState.Lost;
                EndBattle();
            }
            else
            {
                State = BattleState.PlayerTurn;
                PlayerTurn();
            }
        }

        #endregion

        #region Win And Lose

        private void EndBattle()
        {
            switch (State)
            {
                case BattleState.Won:
                    DialogueText.text = "YOU WON THE BATTLE!!!";
                    break;
                case BattleState.Lost:
                    DialogueText.text = "YOU WERE DEFEATED...";
                    break;
            }
        }

        #endregion
    }
}