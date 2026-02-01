using System;
using System.Collections;
using UnityEngine;

public class CurtainController : MonoBehaviour
{
    [SerializeField]
    private GameObject left, right;

    [SerializeField]
    private float timeToWait, duration, speed = 1;

    private bool isTimeToMove;

    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        if (isTimeToMove && duration > 0)
        {
            duration -= Time.deltaTime;
            left.transform.position -= Vector3.left * speed;
            right.transform.position += Vector3.left * speed;
        }

        if (duration <= 0)
        {
            gameObject.SetActive(false);
        }


    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(timeToWait);
        isTimeToMove = true;
    }
}
