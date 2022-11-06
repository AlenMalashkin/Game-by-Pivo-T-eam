using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector3 moveDirection;
    private Transform cameraMain;
    private Rigidbody playerRb;

    public float movementSpeed = 7;
    public float rotationSpeed = 7;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();
        cameraMain = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraMain.forward * playerInput.verticalInput;
        moveDirection = moveDirection + cameraMain.right * playerInput.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= movementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRb.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraMain.forward * playerInput.verticalInput;
        targetDirection = moveDirection + cameraMain.right * playerInput.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotaion = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotaion, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }
}
