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
    }
}
