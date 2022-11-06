using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private PlayerInput playerInput;
    private CameraHandler cameraHandler;
    private PlayerMotion playerMotion;

    private void Awake()
    {
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
