using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    [SerializeField]
    private Transform modelTransform;

    protected Joystick joystick;
    protected Joybutton joybutton;

    public float speedUpdown = 20f;

    public float speedRightLeft = 80f;

    public CharacterController controller;
    private Vector3 localRotation;
    void Start()
    {
        localRotation = transform.localRotation.eulerAngles;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }
    void Update()
    {

        float translation = joystick.Horizontal;
        modelTransform.rotation = Quaternion.Euler(localRotation.x, Mathf.Lerp(-20, 20, translation / 2 + 0.5f), localRotation.z);
        Vector3 move = Vector3.right * translation * speedRightLeft + Vector3.forward * speedUpdown;
        controller.Move(move * Time.deltaTime);


    }
}
