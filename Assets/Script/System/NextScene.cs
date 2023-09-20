using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject pressEText;
    public GameObject pressEscText;

    private bool canContinue = false;

    void Start()
    {
        // Ẩn hai dòng chữ khi bắt đầu
        pressEText.SetActive(false);
        pressEscText.SetActive(false);
    }

    void Update()
    {
        if (canContinue)
        {
            // Nếu người chơi nhấn phím E, chuyển sang scene Menu
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Start_Scene"); // Đổi tên scene của bạn
            }
        }
        else
        {
            // Nếu người chơi nhấn phím Esc, chuyển sang scene Menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Start_Scene"); // Đổi tên scene của bạn
            }
        }
    }

    // Hàm này được gọi từ Timeline khi nội dung intro kết thúc
    public void OnIntroComplete()
    {
        // Hiện dòng chữ "Press E to continue" và cho phép người chơi nhấn E để chuyển scene
        pressEText.SetActive(true);
        canContinue = true;
    }
}
