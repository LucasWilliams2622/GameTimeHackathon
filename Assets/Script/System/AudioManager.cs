using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static float masterVolume = 1.0f; // Biến lưu trữ âm lượng chung

    // Phương thức để thiết lập âm lượng chung
    public static void SetMasterVolume(float volume)
    {
        masterVolume = volume;

        // Điều chỉnh âm lượng của tất cả AudioSource trong scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }
}
