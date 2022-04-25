using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnChildFinger();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public GameObject childFingerPrefab;

    void SpawnChildFinger()
    {
        int childFingerSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(childFingerSpawnIndex).transform;

        Instantiate(childFingerPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}

