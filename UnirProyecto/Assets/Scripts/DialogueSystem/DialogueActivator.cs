using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interactable
{
    [SerializeField] private DialogueObject dialogueObject;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out playermovement player))
        {
            player.Interactable2 = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out playermovement player))
        {
            if(player.Interactable2 is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable2 = null;
            }
        }
    }



    public void Interact(playermovement player)
    {
       player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
