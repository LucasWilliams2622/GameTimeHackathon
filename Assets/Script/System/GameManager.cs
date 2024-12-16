using UnityEngine;
using System; // Để sử dụng Action

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    // Sự kiện kích hoạt pause hoặc resume
    public static event Action<bool> OnPauseStateChanged;

    private bool isPaused = false;

    void Awake()
    {
        // Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        // Kích hoạt sự kiện pause/resume
        OnPauseStateChanged?.Invoke(isPaused);
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
