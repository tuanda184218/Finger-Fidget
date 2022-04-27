using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab;
    // , parentObject;

    [SerializeField]
    private GameObject rootFinger;

    // [SerializeField]
    // [Range(1, 1000)]
    // int length = 1;

    // [SerializeField]
    // float partDistance = 1.1f;

    [SerializeField]
    bool reset, spawn;
    // snapFirst, snapLast;

    public Transform currentSpawnPoint;

    void Start()
    {
        currentSpawnPoint = transform;
    }

    private bool firstInit = true;

    // Update is called once per frame
    void Update()
    {

        // if (reset)
        // {
        //     Destroy(childFingerList[childFingerList.Count - 1]);
        // }

        if (spawn)
        {
            Spawn();
            spawn = false;
        }
    }

    List<GameObject> childFingerList = new List<GameObject>();
    public void Spawn()
    {
        int count = 1;
        for (int x = 0; x < count; x++)
        {
            GameObject tmp;

            Vector3 desiredPosition = new Vector3(currentSpawnPoint.position.x, currentSpawnPoint.position.y, currentSpawnPoint.position.z);

            tmp = Instantiate(partPrefab, currentSpawnPoint.position - currentSpawnPoint.forward, currentSpawnPoint.rotation);
            childFingerList.Add(tmp);
            tmp.transform.eulerAngles = new Vector3(90, 0, 0);
            tmp.name = childFingerList.Count.ToString();

            foreach (GameObject child in childFingerList)
            {
                if (child.gameObject.name.Equals(tmp.name))
                {
                    currentSpawnPoint = child.transform;
                    break;
                }
            }

            if (firstInit)
            {
                tmp.GetComponent<ConfigurableJoint>().connectedBody = rootFinger.GetComponent<Rigidbody>();
                firstInit = false;
            }
            else
            {
                tmp.GetComponent<ConfigurableJoint>().connectedBody = childFingerList[childFingerList.Count - 2].GetComponent<Rigidbody>();
            }

        }
    }
}
