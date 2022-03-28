using System;
using UnityEngine;

namespace Dialogue
{
    public class PlayerInteractComponent : MonoBehaviour
    {
        private PlayerMoveComponent _playerMoveComponent;
        private DialogueProviderComponent _lastDialogueProvider;

        private void Start()
        {
            _playerMoveComponent = GetComponent<PlayerMoveComponent>();
        }

        private void Update()
        {
            if (_lastDialogueProvider)
            {
                var distance = Vector2.Distance(_lastDialogueProvider.gameObject.transform.position, transform.position);
                if (distance >= 2f)
                {
                    DialogueSystem.Instance.HideDialogue();
                }
            }

            if (!Input.GetKeyDown(KeyCode.Space)) return;

            if (!_playerMoveComponent.HitInfo) return;

            if (!_playerMoveComponent.HitInfo.GetComponent<DialogueProviderComponent>()) return;
            
            var dialogueProvider = _playerMoveComponent.HitInfo.GetComponent<DialogueProviderComponent>();
            DialogueSystem.Instance.ShowDialogue(dialogueProvider);
            
            if (dialogueProvider.LineCount == dialogueProvider.Dialogues.Count - 1) return;
            
            dialogueProvider.LineCount++;
            _lastDialogueProvider = dialogueProvider;
        }
    }
}