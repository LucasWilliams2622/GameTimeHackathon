using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject panel;
    public static bool isGameOver;
    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {

    }

    public void GameMenu()
    {
        Time.timeScale = 0;
        Debug.Log("Menu Open");
        panel.SetActive(true);
    }
    public void ResumeGame()    
    {
        Time.timeScale = 1f;
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
