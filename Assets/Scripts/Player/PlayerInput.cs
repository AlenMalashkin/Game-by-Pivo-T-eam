using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private PlayerControlls playerControlls;
    private PlayerAnimations playerAnimations;

    private float moveAmount;
    private UnityEngine.InputSystem.Mouse mouse;

    public Vector2 _moveInput { get; private set; }

    public float verticalInput { get; private set; }
    public float horizontalInput { get; private set; }

    private void OnHealthValueChanged(int changedHealth)
    {
        if (changedHealth <= 0)
        {
            this.enabled = false;
        }
    }


    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void OnEnable()
    {
        healthBar.OnHealthValueChangedEvent += OnHealthValueChanged;

        if (playerControlls == null)
        {
            playerControlls = new PlayerControlls();

            playerControlls.Playermovement.Movement.performed += context => _moveInput = context.ReadValue<Vector2>();
            playerControlls.Attack.Attack.performed += context => HandleMouseInput();
        }

        playerControlls.Enable();
    }

    private void OnDisable()
    {
        healthBar.OnHealthValueChangedEvent -= OnHealthValueChanged;
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

    private void HandleMouseInput()
    {
        playerAnimations.LeftMouseButton();
    }
}
