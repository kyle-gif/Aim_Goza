using System;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Sensitive1 : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateSensitive);
    }

    private void UpdateSensitive(float value)
    {
        slider.value = GameManager.instance.sensitive;
        GameManager.instance.sensitive = value;
    }
}
