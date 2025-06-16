using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{
    public void GoToPlayMenu()
    {
        SceneManager.LoadScene("PlayMenu");
    }
}
