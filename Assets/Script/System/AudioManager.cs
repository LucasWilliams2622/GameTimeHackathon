using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider; // Thanh trượt điều chỉnh âm lượng
    public AudioSource backgroundMusic; // AudioSource chứa nhạc nền
    public Toggle toggle;

    private void Start()
    {

        // Thiết lập giá trị ban đầu của thanh trượt âm lượng
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1.0f);

        // Gán sự kiện cho thanh trượt âm lượng
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    }

    private void Update()
    {
        if (toggle.isOn == true)
        {
            backgroundMusic.mute = false;
        } else
        {
            backgroundMusic.mute = true;
        }
    }

    // Phương thức thay đổi âm lượng
    private void ChangeVolume(float volume)
    {
        // Lưu giá trị âm lượng vào PlayerPrefs để giữ giá trị này sau khi thoát game
        PlayerPrefs.SetFloat("Volume", volume);

        // Cập nhật âm lượng của AudioSource nhạc nền
        backgroundMusic.volume = volume;
    }

}
