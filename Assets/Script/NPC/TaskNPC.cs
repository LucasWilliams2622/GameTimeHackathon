using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TaskNPC : MonoBehaviour
{
    public DIalogBox trigger;
    public GameObject dialogueBox;
    private bool hasTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true && !hasTriggered)
        {
            hasTriggered = true;
            dialogueBox.SetActive(true);
            trigger.StartDialogue();

        }
    }
}