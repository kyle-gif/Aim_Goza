using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    private void Update()
    {
        timerText.text = Mathf.Ceil(10-GameManager.instance.time).ToString();
    }

}
