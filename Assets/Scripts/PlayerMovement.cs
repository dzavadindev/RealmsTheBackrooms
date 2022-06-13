using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight + 0.5f + 0.2f);
        if (grounded)
        {
            playerRB.drag = groundDrag;
        } else
        {
            playerRB.drag = 0;
        }
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calc movement direction

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        playerRB.AddForce(10f * moveSpeed * moveDirection, ForceMode.Force);
    }
}
