using System.Collections;
using UnityEngine;

// 전략패턴 예시(그리드 샷)
public class GridAl : Strategy
{
    
    public float gridSize = 1f;

    public GridAl(GameObject target, Transform shotSpawn) : base(target, shotSpawn)
    {
        
    }

    public override void Strating() // 여기가 메인 함수에요 여기서 실행 시키면 됨.
    {
           Instantiate(target, shotSpawn.position + new Vector3(0,0,-1.5f), Quaternion.identity);
    }

    public override void UpdateStrat() // 업데이트
    {
        
    }
}


