using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // The object to follow
    public Vector3 offset; // Offset from the target
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement
    public Vector3 rotationOffset; // Rotation offset from the target's rotation

    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // Gets called after all other Update functions have finished.
    void LateUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position
        transform.position = smoothedPosition;

        // Adjust the camera's rotation
        Quaternion desiredRotation = Quaternion.Euler(rotationOffset);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed);
    }
}
