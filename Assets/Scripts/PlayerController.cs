using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region
    public static Transform instance;

    private void Awake()
    {
        instance = this.transform;
    }
    #endregion

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
    private float moveX;
    private float moveZ;

    private CharacterController controller;

    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = walk;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!GetComponent<PlayerStats>().IsDead()&&Input.GetKeyDown(KeyCode.Escape))
        {
            QSTXFrameWork.UI.MVP.UIContainer.Instance.Enter(QSTXFrameWork.UI.MVP.UIVIewID.PauseViewID);
            return;
        }
        CheckGrouned();
        JumpAndFall();
        InputToMove();
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if(moveX==0 && moveZ==0)
        {
            anim.SetFloat("Speed", 0, 0.2f, Time.deltaTime);
        }
        else if(!Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 0.5f, 0.2f, Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
        }
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

        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

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
