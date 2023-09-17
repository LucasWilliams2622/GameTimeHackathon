using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ShowIntro : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }

    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("Level 2 Scene 1");
        }
    }
}
