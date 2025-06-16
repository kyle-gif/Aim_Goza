using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSetting : MonoBehaviour
{
    public void GoToSettingMenu()
    {
        SceneManager.LoadScene("Setting");
    }
}
