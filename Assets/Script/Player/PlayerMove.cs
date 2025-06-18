using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Vector3 move;
    private void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(move*Time.deltaTime*5f);
        
    }

    private void Start()
    {
        GameManager.instance.StartGame(1);
    }
}
