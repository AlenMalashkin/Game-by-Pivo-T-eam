using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float _gravity = -9.81f;

    public bool canMove = true;

    private PlayerInput playerInput;
    private Vector3 moveDirection;
    private Transform cameraMain;
    private CharacterController playerController;
    private float _velocity;

    public float movementSpeed = 7;
    public float rotationSpeed = 7;

    private void OnEnable() => healthBar.OnHealthValueChangedEvent += OnHealthValueChanged;
    private void OnDisable() => healthBar.OnHealthValueChangedEvent -= OnHealthValueChanged;

    private void OnHealthValueChanged(int changedHealth)
    {
        if (changedHealth <= 0)
        {
            this.enabled = false;
        }
    }

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<CharacterController>();
        cameraMain = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        Gravity();

        if (canMove)
        {
            HandleMovement();
            HandleRotation();
        }
    }

    private void HandleMovement()
    {
        moveDirection = cameraMain.forward * playerInput.verticalInput;
        moveDirection = moveDirection + cameraMain.right * playerInput.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= movementSpeed * Time.deltaTime;

        playerController.Move(moveDirection);
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

    private void Gravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        playerController.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }
}
