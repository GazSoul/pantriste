using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
   [SerializeField] private GameObject dialogueBox;
   [SerializeField] private TMP_Text textLabel;
   /*[SerializeField] private DialogueObject testDialogue;*/

   public bool IsOpen { get; private set;}

    private TypewriterEffect typewriterEffect;

   private void Start()
   {
      typewriterEffect = GetComponent<TypewriterEffect>();
      CloseDialogueBox();
      /*ShowDialogue(testDialogue);*/
   }

   public void ShowDialogue(DialogueObject dialogueObject)
   {
       IsOpen = true;
       dialogueBox.SetActive(true);
       StartCoroutine(StepThroughtDialogue(dialogueObject));
   }

   private IEnumerator StepThroughtDialogue(DialogueObject dialogueObject)
   {

       yield return new WaitForSeconds(2);

       foreach (string dialogue in dialogueObject.Dialogue)
       {
           yield return typewriterEffect.Run(dialogue, textLabel);
           yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));


       }

       CloseDialogueBox();
   }

   private void CloseDialogueBox()
   {
       IsOpen = false;
       dialogueBox.SetActive(false);
       textLabel.text = string.Empty;
   }
}
