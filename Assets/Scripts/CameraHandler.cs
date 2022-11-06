using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public float minCollisionOffset = 0.2f;
    public float cameraCollisionOffset = 0.2f;
    public float cameraCollistionsRadius = 2f;
    public float cameraFollowSpeed = 0.2f;
    public float cameraLookSpeed = 0.2f;
    public float cameraPivotSpeed = 2;
    public float minPivotAngle = -35;
    public float maxPivotAngle = 35;

    public float lookAngle;
    public float pivotAngle;

    public LayerMask collisionLayers;
    public Transform targetTransform;
    public Transform cameraPivot;
    public Transform cameraTransform;
    private float defaultPosition;
    private Vector3 cameraFollowVellocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        targetTransform = FindObjectOfType<Player>().transform;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVellocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        //lookAngle = lookAngle + (playerInput.cameraInputX * cameraLookSpeed);
        //pivotAngle = pivotAngle - (playerInput.cameraInputY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollistionsRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition -= (distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minCollisionOffset)
        {
            targetPosition = targetPosition - minCollisionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z , targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
