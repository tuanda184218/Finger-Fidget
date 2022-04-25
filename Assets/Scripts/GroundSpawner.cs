﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    // Start is called before the first frame update

    public void SpawnTile()
    {
        GameObject tmp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tmp.transform.GetChild(1).transform.position;
    }
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

}
