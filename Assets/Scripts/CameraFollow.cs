using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float positionSpeed;
    [SerializeField] private float rotationSpeed;

    private Transform camera;

    private void Start()
    {
        camera = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        HandleTranslation();
    }

    private void HandleTranslation()
    {
        Vector3 targetPosition = objectToFollow.TransformPoint(offset);
        camera.position = Vector3.Lerp(camera.position, targetPosition, positionSpeed * Time.deltaTime);
        Quaternion rotation = Quaternion.LookRotation(targetPosition - camera.position, Vector3.up);
        
        camera.rotation = Quaternion.Lerp(camera.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
