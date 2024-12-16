using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogBox : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public SFX[] sfxs;

    [SerializeField] GameManager gameManager;
    public void StartDialogue()
    {
        FindObjectOfType<DialogManager>().OpenDialogue(messages, actors, sfxs);
    }
}

    [System.Serializable]
    public class Message
    {
        public int actorId;
        public string message;
    }
    [System.Serializable]
    public class Actor
    {
        public string name;
        public Sprite sprite;
    }

    [System.Serializable]
    public class SFX
    {
        public AudioSource audioSource;
    }
