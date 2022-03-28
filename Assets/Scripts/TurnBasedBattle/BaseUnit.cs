using UnityEngine;

namespace TurnBasedBattle
{
    public class BaseUnit : MonoBehaviour
    {
        public string UnitName;
        public int UnitLevel;

        public int Damage;
        public int MaxHp;
        public int CurrentHp;

        public bool TakeDamage(int damage)
        {
            CurrentHp -= damage;

            return CurrentHp <= 0;
        }
    }
}
