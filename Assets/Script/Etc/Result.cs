using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text text;
    private int i;
    private void Start()
    {
        text.text = GameManager.instance.Count.ToString();
        GameManager.instance.Count = 0;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
