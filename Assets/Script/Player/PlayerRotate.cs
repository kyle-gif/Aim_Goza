using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    //public GameObject player;
    

    private float verticalRotation = 0f;
    private float horizontal;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * GameManager.instance.sensitive;
        float mouseY = Input.GetAxis("Mouse Y") * GameManager.instance.sensitive;
        //player.transform.Rotate(0, mouseX, 0);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -45f, 45f);

        
        horizontal += mouseX;
        transform.localEulerAngles = new Vector3(verticalRotation, horizontal, 0);
        Debug.DrawRay(transform.position, transform.forward*10000, Color.red);
        Shoot();
    }

    public void Shoot()
    {
        if (GameManager.instance.TargetID == 1)
        {
            if (Physics.Raycast(transform.position, transform.forward * 10000, out RaycastHit hit))
            {
                hit.transform.GetComponent<Target>().OnHit();
            }
                
        }
        else if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward*10000, out RaycastHit hit))
        {
            hit.transform.GetComponent<Target>().OnHit();
        }
    }
    private void Start()
    {
        GameManager.instance.StartGame(1);
    }
}