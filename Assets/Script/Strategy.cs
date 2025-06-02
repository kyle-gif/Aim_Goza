using System.Collections.Generic;
using UnityEngine;

public abstract class Strategy : MonoBehaviour
{
    protected GameObject target;
    protected Transform shotSpawn;

    public Strategy(GameObject target, Transform shotSpawn)
    {
        this.target = target;
        this.shotSpawn = shotSpawn;
    }

    public abstract void Strating(); //전략패턴 함수 실행 쓸때 재정의 해라 앧즐아
    public abstract void UpdateStrat();
}

public class STM
{
    private Strategy strategy;
    
    public STM(Strategy strategy)
    {
        this.strategy = strategy;
    }
    private void DoStrategy()
    {
        strategy.Strating();
    }

    public void UpdateStrategy()
    {
        strategy.UpdateStrat();
    }

    public void SetStrategy(Strategy strategy)
    {
        this.strategy = strategy;
        this.DoStrategy();
    }
}
