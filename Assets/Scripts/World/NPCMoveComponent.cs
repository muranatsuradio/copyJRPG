using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace World
{
    public class NpcMoveComponent : BaseMoveComponent
    {
        public GameObject Player;
        public bool CanNpcFollow;

        protected override void Update()
        {
            var player = Player.GetComponent<PlayerMoveComponent>();
            if (!CanNpcFollow) return;
            if (player.HorizontalInput + player.VerticalInput == 0)
            {
                HorizontalInput = 0;
                VerticalInput = 0;
                return;
            }

            HorizontalInput = Player.GetComponent<PlayerMoveComponent>().HorizontalInput;
            VerticalInput = Player.GetComponent<PlayerMoveComponent>().VerticalInput;
            base.Update();
        }
    }
}
