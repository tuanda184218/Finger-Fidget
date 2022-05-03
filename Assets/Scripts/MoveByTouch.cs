using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    [SerializeField]
    private Transform modelTransform;

    protected Joystick joystick;
    protected Joybutton joybutton;

    public float speedUpdown = 10f;

    public float speedRightLeft = 10f;

    // public float smoothSpeed = 0.5f;

    public CharacterController controller;

    // Variables for Gravity
    public float gravity;
    public Vector3 velocity;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundMask;
    public bool isGround;

    private Vector3 localRotation;
    void Start()
    {
        localRotation = transform.localRotation.eulerAngles;
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        controller = GetComponent<CharacterController>();

    }
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);

        if (isGround && velocity.y >= -1)
        {
            velocity.y = -1;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        float translation = joystick.Horizontal;
        modelTransform.rotation = Quaternion.Euler(localRotation.x, Mathf.Lerp(-20, 20, translation / 2 + 0.5f), localRotation.z);
        Vector3 move = Vector3.right * translation * speedRightLeft + Vector3.forward * speedUpdown;
        controller.Move(move * Time.deltaTime);

    }
}
