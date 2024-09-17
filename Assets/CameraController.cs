using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraHeight = 10f;
    public float cameraZoom = 5f;

    void Start()
    {
        // Set the camera's initial position and rotation
        transform.position = new Vector3(0, cameraHeight, 0);
        transform.rotation = Quaternion.identity;
    }

    void LateUpdate()
    {
        // Adjust the camera's zoom level based on the game state
        float zoom = cameraZoom;
        // You can add logic here to adjust the zoom level based on the snake's length, speed, or other factors
        Camera.main.orthographicSize = zoom;
    }
}
