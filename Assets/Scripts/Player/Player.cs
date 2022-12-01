using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private PlayerInput playerInput;
    private CameraHandler cameraHandler;
    private PlayerMotion playerMotion;

    private void OnEnable() => healthBar.OnHealthValueChangedEvent += OnHealthValueChanged;
    private void OnDisable() => healthBar.OnHealthValueChangedEvent -= OnHealthValueChanged;

    private void OnHealthValueChanged(int changedHealth)
    {
        if (changedHealth <= 0)
        {
            this.enabled = false;
        }
    }

    private void Start()
    {
        CursorEnabler.Instance.DisableCursor();
        playerInput = GetComponent<PlayerInput>();
        playerMotion = GetComponent<PlayerMotion>();
        cameraHandler = FindObjectOfType<CameraHandler>();
    }

    private void Update()
    {
        playerInput.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerMotion.HandleAllMovement();
    }
}
