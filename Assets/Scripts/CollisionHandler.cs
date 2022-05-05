using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private FingerBlaBla fingerSpawn;

    public float timer;
    [SerializeField]
    private float countDownTime;

    private Movement move;

    private void OnEnable()
    {
        timer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            Debug.Log("food!!");
            collectFinger();
        }
        else if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("obstacle!");
            stopFinger();
            uncollectFinger();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            // Debug.Log("ST");
            // stopFinger();
            RunUncollectTimer();
            // unStopFinger();
        }
    }

    private void RunUncollectTimer()
    {
        timer += Time.deltaTime;
        if (timer >= countDownTime)
        {
            timer = 0;
            uncollectFinger();
            Debug.Log("Uncollected!!!");
        }
    }

    private void collectFinger()
    {
        fingerSpawn.SpawnFinger();
    }

    private void unStopFinger()
    {
        GetComponent<Movement>().isStopped = false;
        GetComponent<FingerBlaBla>().isStopped = false;
    }
    private void stopFinger()
    {
        GetComponent<Movement>().isStopped = true;
        GetComponent<FingerBlaBla>().isStopped = true;
    }

    private void uncollectFinger()
    {
        fingerSpawn.DestroyFinger();
    }
}
