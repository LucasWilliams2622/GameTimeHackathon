using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject pressEText;
    public GameObject pressEscText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Start_Scene");
        }

       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start_Scene");
        }     
    }

}
