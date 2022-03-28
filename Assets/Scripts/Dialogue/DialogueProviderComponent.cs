using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class DialogueProviderComponent : MonoBehaviour
    {
        public string Name;
        
        public List<string> Dialogues = new List<string>();

        public int LineCount;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            DialogueSystem.Instance.ShowDialogue(this);
            if (LineCount == Dialogues.Count - 1)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    DialogueSystem.Instance.HideDialogue();
                }
                return;
            };
            LineCount++;
        }
    }
}
