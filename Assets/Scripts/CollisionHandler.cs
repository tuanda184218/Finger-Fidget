using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private FingerSpawn fingerSpawn;
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
        }
    }

    private void collectFinger()
    {
        fingerSpawn.Spawn();
    }
}
