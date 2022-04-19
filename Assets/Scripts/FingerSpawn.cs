﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab, parentObject;

    [SerializeField]
    [Range(1, 1000)]
    int length = 1;

    [SerializeField]
    float partDistance = 0.75f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;

    public Transform currentSpawnPoint;

    void Start()
    {
        currentSpawnPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject tmp;
        // tmp = Instantiate(partPrefab, new Vector3(currentSpawnPoint.position.x, currentSpawnPoint.position.y, currentSpawnPoint.position.z), Quaternion.identity, parentObject.transform);
        // tmp.transform.eulerAngles = new Vector3(90, 0, 0);
        // tmp.name = parentObject.transform.childCount.ToString();

        // foreach (Transform child in parentObject.transform)
        // {
        //     if (child.gameObject.name.Equals(tmp.name))
        //     {
        //         currentSpawnPoint = child;
        //         break;
        //     }
        // }
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();
            spawn = false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length / partDistance);
        for (int x = 0; x < count; x++)
        {
            GameObject tmp;

            Vector3 desiredPosition = new Vector3(currentSpawnPoint.position.x, currentSpawnPoint.position.y, currentSpawnPoint.position.z - partDistance * 2 * (x + 1));

            // tmp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - partDistance * 2 * (x + 1)), Quaternion.identity, parentObject.transform);
            tmp = Instantiate(partPrefab, desiredPosition, Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(90, 0, 0);
            tmp.name = parentObject.transform.childCount.ToString();

            foreach (Transform child in parentObject.transform)
            {
                if (child.gameObject.name.Equals(tmp.name))
                {
                    currentSpawnPoint = child;
                    break;
                }
            }

            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
        if (snapLast)
        {
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
