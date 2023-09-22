using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.SetActive(true);
    }
}
