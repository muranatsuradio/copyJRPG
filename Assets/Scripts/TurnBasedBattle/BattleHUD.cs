using UnityEngine;
using UnityEngine.UI;

namespace TurnBasedBattle
{
    public class BattleHUD : MonoBehaviour
    {
        public Text NameText;
        public Text LevelText;
        public Image HpSlider;

        public void SetHUD(BaseUnit unit)
        {
            NameText.text = unit.UnitName;
            LevelText.text = "Lv: " + unit.UnitLevel;
            
            if (unit.MaxHp == 0) return;
            HpSlider.fillAmount = (float)unit.CurrentHp / (float)unit.MaxHp;
        }

        public void SetHp(float hp)
        {
            HpSlider.fillAmount = hp;
        }
    }
}
