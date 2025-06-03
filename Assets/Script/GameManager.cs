using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] targets;
    public Transform spawnPoint;
    private STM strategy = new STM(null);
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
    }

    private void Update()
    {
        strategy.UpdateStrategy();
    }
}
