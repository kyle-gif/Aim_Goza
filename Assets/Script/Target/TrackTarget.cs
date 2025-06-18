using UnityEngine;
using System.Collections;

public class TrackTarget : Target
{
    [SerializeField] private float speed = 3;
    private Vector3 dest;
    private float time;
    private bool isMoving = false;

    private void Start()
    {
        StartCoroutine(MoveTarget());
    }

    private void Update()
    {
        if (!isMoving) return;

        transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, dest) < 0.01f)
        {
            StartCoroutine(MoveTarget());
        }
    }

    IEnumerator MoveTarget()
    {
        isMoving = false;

        dest = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-3.0f, 8.0f), 14);

        yield return new WaitForSeconds(0.1f);

        isMoving = true;
    }

    public override void OnHit()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            time = 0;
            GameManager.instance.Count++;
        }
    }
}