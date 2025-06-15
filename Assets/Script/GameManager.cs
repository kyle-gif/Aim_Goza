using UnityEditor.MemoryProfiler;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] targets;
    public Transform spawnPoint;
    private STM strategy = new STM(null);
    public float time = 0;
    public ScoreSubmitter submit;

    private bool onGame = false;
    public int Count;
    public bool Ongame
    {
        get => onGame;
        set
        {
            onGame = value;
            Cursor.visible=false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GridAl gridAl = gameObject.AddComponent<GridAl>();
        gridAl.Initialize(targets[0], spawnPoint);
        strategy.SetStrategy(gridAl);
        Ongame = true;
    }

    private void Update()
    {
        strategy.UpdateStrategy();
        
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
