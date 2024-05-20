using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target that the camera will follow (your player)
    public Vector3 offset; // The offset distance between the camera and the target
    public float smoothSpeed = 0.125f; // The speed at which the camera will smooth

    void FixedUpdate()
    {
        if (target != null)
        {
            // Desired position based on the target's position and the offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the camera's current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
