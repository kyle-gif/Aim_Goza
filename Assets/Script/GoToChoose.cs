using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToChoose : MonoBehaviour
{
    public void GoToChooseMenu()
    {
        SceneManager.LoadScene("ChooseMenu");
    }
}
