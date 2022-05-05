using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerBlaBla : MonoBehaviour
{
    [SerializeField]
    private GameObject rootFinger;

    [SerializeField]
    private GameObject childFinger;
    [SerializeField]
    bool reset = true, spawn = true;

    [SerializeField]
    public bool isStopped;
    private List<Transform> childFingerTransforms = new List<Transform>();

    void Start()
    {
        // spawn next finger after this transform
        // Transform transformToSpawnAfter = rootFinger.transform;

        // for (int i = 0; i < 10; i++)
        // {
        //     Transform spawnedFinger = Instantiate(childFinger, transformToSpawnAfter.position - transformToSpawnAfter.forward, transformToSpawnAfter.rotation).transform;
        //     childFingerTransforms.Add(spawnedFinger);
        //     transformToSpawnAfter = spawnedFinger;
        // }
    }

    public void Update()
    {
        if (reset)
        {
            DestroyFinger();
            reset = false;
        }

        // if (Input.GetAxis("Vertical") > 0)
        if (spawn)
        {
            SpawnFinger();
            spawn = false;
        }
        if (!isStopped)
            UpdateFinger();

    }

    public void DestroyFinger()
    {
        if ((childFingerTransforms.Count != 0) && (childFingerTransforms[childFingerTransforms.Count - 1] != null))
        {
            Debug.Log(childFingerTransforms.Count);
            Destroy(childFingerTransforms[childFingerTransforms.Count - 1].gameObject);

            childFingerTransforms.RemoveAt(childFingerTransforms.Count - 1);
        }
    }

    public void SpawnFinger()
    {
        Transform transformToSpawnAfter = rootFinger.transform;
        int count = 1;
        for (int x = 0; x < count; x++)
        {
            Transform spawnedFinger = Instantiate(childFinger, transformToSpawnAfter.position - transformToSpawnAfter.forward, transformToSpawnAfter.rotation).transform;
            childFingerTransforms.Add(spawnedFinger);
            transformToSpawnAfter = spawnedFinger;
        }
    }

    void UpdateFinger()
    {
        Transform transformToFollow = rootFinger.transform;

        for (int i = 0; i < childFingerTransforms.Count; i++)
        {
            if (childFingerTransforms[i] != null)
            {
                childFingerTransforms[i].transform.position = Vector3.Lerp(childFingerTransforms[i].transform.position, transformToFollow.position, .1f);
                childFingerTransforms[i].transform.rotation = Quaternion.Lerp(childFingerTransforms[i].transform.rotation, transformToFollow.rotation, .1f);
                transformToFollow = childFingerTransforms[i];
            }
        }
    }
}
