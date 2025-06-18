using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    
    public void ButtonFunc(string btnName)
    {
        SceneManager.LoadScene(btnName);
    }

    public void LoadGrid()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.instance.TargetID = 0;
    }

    public void LoadTrack()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.instance.TargetID = 1;
    }
}
