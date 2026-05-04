using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform target; // Drag your player here
    public Vector3 offset = new Vector3(0, 5, -10); // The distance from the player

    void LateUpdate() 
    {
        // Move the camera to the player's position plus the offset
        transform.position = target.position + offset;

        // Keep the camera pointed at the player
        transform.LookAt(target);
    }
}