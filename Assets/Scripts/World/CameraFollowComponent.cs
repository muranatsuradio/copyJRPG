using System;
using UnityEngine;

namespace World
{
    public class CameraFollowComponent : MonoBehaviour
    {
        public GameObject Player;
        public GameObject TriggerVolume;

        private bool _canFollow;
        private float _progressTarget;
        private void Update()
        {
            var distance = Player.transform.position.y - TriggerVolume.transform.position.y;
            if (distance <= 0.5f)
            {
                _canFollow = true;
            }

            if (!_canFollow) return;
            
            var targetPosition = new Vector3(Player.transform.position.x, Player.transform.position.y,
                transform.position.z);
            
            _progressTarget = _progressTarget > 1 ? _progressTarget : _progressTarget + Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _progressTarget);
        }
    }
}