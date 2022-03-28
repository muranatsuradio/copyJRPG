using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace World
{
    [Serializable]
    public enum Level
    {
        Room,
        Village,
        Wild,
        BattleScene,
    }
    
    public class LevelChangeSystem : MonoBehaviour
    {
        [SerializeField] private Level Scene;
        [SerializeField] private GameObject Player;
        [SerializeField] private GameObject TriggerVolume;

        private void Update()
        {
            var distance = Vector2.Distance(Player.transform.position, TriggerVolume.transform.position);

            if (distance <= 1f)
            {
                SceneManager.LoadScene(Scene.ToString());
            }
        }
    }
}