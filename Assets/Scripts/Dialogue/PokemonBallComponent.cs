using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Dialogue
{
    public class PokemonBallComponent : MonoBehaviour
    {
        private DialogueProviderComponent _dialogueProvider;

        private void Start()
        {
            _dialogueProvider = GetComponent<DialogueProviderComponent>();
        }

        private void Update()
        {
            if (_dialogueProvider.LineCount == _dialogueProvider.Dialogues.Count - 1)
            {
                Invoke(nameof(DestroySelf), 1.5f);
            }
        }

        private void DestroySelf()
        {
            gameObject.SetActive(false);
        }
    }
}