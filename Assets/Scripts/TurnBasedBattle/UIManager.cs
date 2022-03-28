using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TurnBasedBattle
{
    public class UIManager : MonoBehaviour
    {
        public List<GameObject> UIMenu = new List<GameObject>();

        private void Start()
        {
            foreach (var menu in UIMenu.Where(menu => UIMenu.IndexOf(menu) != 0))
            {
                menu.SetActive(false);
            }
        }
    }
}
