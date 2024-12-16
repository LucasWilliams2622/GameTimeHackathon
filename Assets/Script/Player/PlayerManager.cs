using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    public GameObject panel;
    public static bool isGameOver;
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        isGameOver = false;
    }

    void Update()
    {

    }

    public void GameMenu()
    {
        Time.timeScale = 0;
        playerMovement.DisableMovement();
        Debug.Log("Menu Open");
        panel.SetActive(true);
    }
    public void ResumeGame()    
    {
        Time.timeScale = 1f;
        playerMovement.EnableMovement();
        panel.SetActive(false);
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Start_Scene");
    }
}
