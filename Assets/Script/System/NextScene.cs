using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject pressEscText;
    [SerializeField] GameObject startGameButton;

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape) && pressEscText.activeSelf)
        {
            SceneManager.LoadScene("Start_Scene");
        }     

        if (Input.anyKeyDown && startGameButton.activeSelf)
        {
            StartCoroutine(LoadSceneWithDelay(0.5f));
        }     


    }

    IEnumerator LoadSceneWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Start_Scene");
    }

}
