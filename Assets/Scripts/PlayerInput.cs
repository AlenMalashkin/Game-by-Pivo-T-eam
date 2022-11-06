using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInput : MonoBehaviour
{
    private PlayerControlls playerControlls;
    private PlayerAnimations playerAnimations;

    private float moveAmount;

    public Vector2 _moveInput { get; private set; }

    public float verticalInput { get; private set; }
    public float horizontalInput { get; private set; }

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void OnEnable()
    {
        if (playerControlls == null)
        {
            playerControlls = new PlayerControlls();

            playerControlls.Playermovement.Movement.performed += i => _moveInput = i.ReadValue<Vector2>();
        }

        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = _moveInput.y;
        horizontalInput = _moveInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        playerAnimations.UpdateAnimatorValues(0, moveAmount);
    }
}
