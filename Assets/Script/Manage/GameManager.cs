using UnityEditor.MemoryProfiler;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public float time = 0;
    public ScoreSubmitter submit;
    
    public GameObject[] targets;
    private bool onGame = false;
    public int Count;
    
    public bool Ongame
    {
        get => onGame;
        set
        {
            onGame = value;
            Cursor.visible=!value;
            Cursor.lockState = (value) ? CursorLockMode.Locked :CursorLockMode.None;
        }
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        
    }

    public void StartGame(int count)
    {
        
        Instantiate(targets[count],new Vector3(4,6,14),Quaternion.identity);
        Ongame = true;
    }


    private void LateUpdate()
    {
        if(!onGame)
            return;
        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            onGame = false;
            int finalScore = Count;
            string userName = "TestUser";
            if (submit != null)
            {
                submit.SubmitScore(userName, finalScore);
                Debug.Log(Count + " 값이 정상적으로 전달됨");
            }
            else
            {
                Debug.LogWarning("ScoreSubmitter가 연결되지 않았습니다!");
            }
        }
            
    }
    
}
