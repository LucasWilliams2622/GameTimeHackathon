using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    #region Props
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform BackgroundBox;
    public AudioSource audioSource;
    Message[] currentMessages;
    Actor[] currentActors;
    SFX[] currentsfxs;

    [SerializeField] GameObject player;
    int activeMessage = 0;


    public static bool isActive = false;
    #endregion


    public void OpenDialogue(Message[] messages, Actor[] actors, SFX[] sfxs) // open method
    {
        currentMessages = messages;
        currentActors = actors;
        currentsfxs = sfxs;
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
            player.GetComponent<PlayerMovement>().EnableMovement();
            isActive = false;
            gameObject.SetActive(false);
        }
    }

    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessage();
        }
    }
}
