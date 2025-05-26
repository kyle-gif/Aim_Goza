using UnityEngine;
using UnityEngine.InputSystem.Controls;


public class PlayerRotate : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");


        transform.eulerAngles += new Vector3(-Mathf.Clamp(y, -45f, 45f), -Mathf.Clamp(x, -45f, 45f), 0);
    }
}
