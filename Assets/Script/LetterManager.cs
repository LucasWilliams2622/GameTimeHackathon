using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject canvas;
    [SerializeField] PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMovement != null)
        {
            playerMovement.DisableMovement();
        }
        canvas.SetActive(true);
    }

    public void EnablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.EnableMovement();
        }
    }
}
