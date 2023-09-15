using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    #region Props
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform BackgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;


    public static bool isActive = false;
    #endregion


    public void OpenDialogue(Message[] messages, Actor[] actors) // open method
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        DislayMessage();
    }

    void DislayMessage() // show messages
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

    }

    public void NextMessage() // next messages
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DislayMessage();
        }
        else
        {
            Debug.Log("Finish!");
            isActive = false;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessage();
        }
    }
}
