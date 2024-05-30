using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 10f;
    public float runSpeed = 12f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private bool canMove = true;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor
        Cursor.visible = false;
    }

    void Update()
    {
        if (!canMove)
            return; // If canMove is false, exit Update

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal");

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Apply gravity
        if (characterController.isGrounded)
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection.y = movementDirectionY - gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    // Method to toggle movement
    public void ToggleMovement(bool canMove)
    {
        this.canMove = canMove;
    }
}
