using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    protected Joystick joystick;
    protected Joybutton joybutton;
    private Vector3 localRotation;
    private Transform modelTransform;
    public float speed = 13.0F;
    public float rotateSpeed = 10.0F;
    public bool isStopped;
    void Start()
    {
        localRotation = transform.localRotation.eulerAngles;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }
    void FixedUpdate()
    {
        if (isStopped)
        {
            return;
        }

        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        float translation = joystick.Horizontal;
        // transform.Rotate(0, Input.GetAxis("Horizontal") != 0 ? Mathf.Sign(Input.GetAxis("Horizontal")) * rotateSpeed : 0, 0);
        transform.rotation = Quaternion.Euler(localRotation.x, Mathf.Lerp(-25, 25, translation / 2 + 0.5f), localRotation.z);



        // Move forward / backward
        // Vector3 forward = transform.TransformDirection(Vector3.forward);
        // float curSpeed = Input.GetAxis("Vertical") != 0 ? speed * Mathf.Sign(Input.GetAxis("Vertical")) : 0;
        // controller.SimpleMove(forward * curSpeed);

        Vector3 move = Vector3.right * translation * rotateSpeed + Vector3.forward * speed;
        controller.Move(move * Time.deltaTime);
    }
}
