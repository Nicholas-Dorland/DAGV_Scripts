using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    public GameObject player;

    private float speed = 200;

    // Update is called once per frame
    void Update()
    {
        // When input is given, rotate the camera.
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
