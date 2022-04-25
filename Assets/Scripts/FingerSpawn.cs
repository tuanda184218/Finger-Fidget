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

    [SerializeField]
    float partDistance = 1.1f;

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

            Vector3 desiredPosition = new Vector3(currentSpawnPoint.position.x, currentSpawnPoint.position.y, currentSpawnPoint.position.z - partDistance);

            // tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - partDistance * 2 * (x + 1)), Quaternion.identity, parentObject.transform);
            tmp = Instantiate(partPrefab, desiredPosition, Quaternion.identity);
            childFingerList.Add(tmp);
            tmp.transform.eulerAngles = new Vector3(90, 0, 0);
            // tmp.name = parentObject.transform.childCount.ToString();
            tmp.name = childFingerList.Count.ToString();

            // foreach (Transform child in parentObject.transform)  // di chuyen con tro xuong duoi // use List
            // {
            //     if (child.gameObject.name.Equals(tmp.name))
            //     {
            //         currentSpawnPoint = child;
            //         break;
            //     }
            // }

            foreach (GameObject child in childFingerList)
            {
                if (child.gameObject.name.Equals(tmp.name))
                {
                    currentSpawnPoint = child.transform;
                    break;
                }
            }

            // if (x == 0)
            // {
            //     Destroy(tmp.GetComponent<CharacterJoint>());
            //     tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            // }
            // else
            // {
            //     tmp.GetComponent<CharacterJoint>().connectedBody = childFingerList[childFingerList.Count - 2].GetComponent<Rigidbody>();
            // }


            if (firstInit)
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = rootFinger.GetComponent<Rigidbody>();
                firstInit = false;
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = childFingerList[childFingerList.Count - 2].GetComponent<Rigidbody>();
            }

        }
    }
}

// if (snapLast)
// {
//parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
// }
