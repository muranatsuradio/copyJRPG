using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedBattle
{
    public class BattleHUD : MonoBehaviour
    {
        public Text NameText;
        public Text LevelText;
        public Slider HpSlider;

        public void SetHUD(BaseUnit unit)
        {
            NameText.text = unit.UnitName;
            LevelText.text = "Lv: " + unit.UnitLevel;
            HpSlider.maxValue = unit.MaxHp;
            HpSlider.value = unit.CurrentHp;
        }

        public void SetHp(int hp)
        {
            HpSlider.value = hp;
        }
    }
}
