using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("childFinger"))
        {
            Debug.Log("You've eaten childFinger!");
            changeLength();
        }
        else
        {
            Debug.Log("What sup bro!");
        }
    }

    void changeLength()
    {
        // Vector3 objectScale = transform.localScale;
        // transform.localScale = new Vector3(0, 0, objectScale.z * 2);
    }
}
