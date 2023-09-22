using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject pressE;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressE.SetActive(false);
    }

}
