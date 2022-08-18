using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    // Set the camera offset Z value to -10 or lower
    public Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    private void Awake()
    {
        // Change the ("Player") to the name of the thing you want the camera follow
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        transform.position = player.position + cameraOffset;
    }

    void FixedUpdate()
    {
        Vector3 finalPosition = player.position + cameraOffset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
        transform.position = lerpPosition;
    }
}
