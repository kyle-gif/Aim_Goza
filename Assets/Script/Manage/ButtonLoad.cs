using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
    
    public void ButtonFunc(string btnName)
    {
        SceneManager.LoadScene(btnName);
    }

    public void ChangeCanvas()
    {
        
    }
}
