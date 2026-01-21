using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float timeOffset; // Time offset for smooth movement
    public Vector3 positionOffset; // Position offset from the player
    private Vector3 velocity; // Velocity reference for SmoothDamp

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + positionOffset, ref velocity, timeOffset);
    }
}
