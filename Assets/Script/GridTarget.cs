using System.Collections;
using UnityEngine;

public class GridTarget : Target
{
    private Vector3[] gridLoc;
    [SerializeField] private float gridSize =1f;
    private void Start()
    {
        gridLoc = new Vector3[9];
        for (int i = 0; i < 9; i++)
        {
            gridLoc[i] = new Vector3(i*gridSize, i*gridSize+4,25);
        }
        StartCoroutine("UpdateTarget");
    }
    
    
    public override void OnHit()
    {
        transform.position = gridLoc[Random.Range(0, gridLoc.Length)];
        // 그 뭐시냐 점수 올리는 코드 만들어야할 자리
    }

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            OnHit();
            yield return new WaitForSeconds(3f);
        }
    }
}
