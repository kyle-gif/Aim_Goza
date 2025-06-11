using System.Collections;
using UnityEngine;

public class GridTarget : Target
{
    [SerializeField] private float gridSize =3f;
    private Vector3[] targetPos = new Vector3[9];


    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            targetPos[i] = new Vector3(i-1, i, 11);
        }
        //StartCoroutine("UpdateTarget");
    }
    
    
    public override void OnHit()
    {
        transform.position = targetPos[Random.Range(0, 9)]* 1f;
        GameManager.instance.Count += 1;
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
