using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walk;
    [SerializeField] private float run;

    [Header("Jump and fall")]
    [SerializeField] private float jump;
    [SerializeField] private float gravity;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask gMask;
    [SerializeField] private bool isGrounded = false;
    private Vector3 velocity = Vector3.zero;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = walk;
    }

    private void Update()
    {
        CheckGrouned();
        JumpAndFall();
        InputToMove();
    }

    private void InputToMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = run;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walk;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(moveX, 0, moveZ);
        direction = direction.normalized;
        direction = transform.TransformDirection(direction);

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    private void CheckGrouned()
    {
        isGrounded = Physics.CheckSphere(transform.position, distance);
    }

    private void JumpAndFall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jump * -2f * gravity);
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
