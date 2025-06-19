using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLoad : MonoBehaviour
{
    
    public void ButtonFunc(string btnName)
    {
        SceneManager.LoadScene(btnName);
    }

    public void SetUserName(InputField inputField)
    {
        GameManager.instance.userName = inputField.text;
    }
    

    public void LoadGrid()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.instance.Ongame = true;
        GameManager.instance.TargetID = 0;
    }

    public void LoadTrack()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.instance.Ongame = true;
        GameManager.instance.TargetID = 1;
    }
}
