using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] targets;
    public Transform spawnPoint;
    private STM strategy = new STM(null);
    public float time = 0;

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
        if (time > 30)
        {
            time = 0;
            Debug.Log("류한석 병신");
            //여기에 넣으면 됨.
        }
            
    }
    
}
