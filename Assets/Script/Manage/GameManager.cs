using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public float time = 0;
    public ScoreSubmitter submit;
    public float sensitive =1 ;
    public GameObject[] targets;
    public bool onGame = false;
    public int Count;
    public int TargetID;
    public string userName;
    
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
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }
        
    }

    private void Start()
    {
    }

    public void StartGame(int count)
    {
        
        Instantiate(targets[TargetID],new Vector3(4,6,14),Quaternion.identity);
        Ongame = true;
    }


    private void LateUpdate()
    {
        if (!onGame)
        {
            return;
            
        }
        time += Time.deltaTime;
        //시간제한 바꾸기
        if (time > 10)
        {
            time = 0;
            Ongame= false;
            SceneManager.LoadScene("ResultScene");
            int finalScore = Count;
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
