using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerCamera : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;
    void Start()
    {
        initalOffset = transform.position - targetObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = targetObject.position + initalOffset;
        transform.position = cameraPosition;
    }
}
