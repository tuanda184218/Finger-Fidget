using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerRotation : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        // Vector3 rotationEuler = transform.rotation.eulerAngles;
        // rotationEuler.x += rotateSpeed * Time.deltaTime;
        // Debug.Log(rotationEuler.x);
        // rotationEuler.y = rotationEuler.z = 0;

        // transform.rotation = Quaternion.Euler(rotationEuler);
        transform.Rotate(rotateSpeed, 0, 0, Space.Self);
    }
}
