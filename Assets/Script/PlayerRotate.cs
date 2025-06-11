using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 3f;

    private float verticalRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        player.transform.Rotate(0, mouseX, 0);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f);

        transform.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        Debug.DrawRay(transform.position, transform.forward*10000, Color.red);
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward*10000, out RaycastHit hit))
        {
            hit.transform.GetComponent<Target>().OnHit();
        }
    }
}