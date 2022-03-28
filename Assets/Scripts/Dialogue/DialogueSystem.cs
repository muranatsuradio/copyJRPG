using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueSystem : Singleton<DialogueSystem>
    {
        public GameObject DialogueBox;
        public Text NameText;
        public Text DialogueText;

        private void Start()
        {
            DialogueBox.SetActive(false);
        }

        public void ShowDialogue(DialogueProviderComponent dialogueProvider)
        {
            DialogueBox.SetActive(true);
            NameText.text = dialogueProvider.Name;
            DialogueText.text = dialogueProvider.Dialogues[dialogueProvider.LineCount];
        }

        public void HideDialogue()
        {
            DialogueBox.SetActive(false);
        }
    }
}
