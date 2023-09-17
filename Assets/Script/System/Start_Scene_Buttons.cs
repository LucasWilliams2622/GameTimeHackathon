using UnityEngine.UI;
using UnityEngine;

public class Start_Scene_Buttons : MonoBehaviour
{
    public GameObject Settings;
    void OpenSetting()
    {
       Settings.SetActive(true);
    }

    void CloseSetting()
    {
       Settings.SetActive(false);
    }
}
